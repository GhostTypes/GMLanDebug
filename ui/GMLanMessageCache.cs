using System;
using System.Collections.Concurrent;
using System.Threading;
using GMLanDebug.util;

namespace GMLanDebug.ui
{
    public class GMLanMessageCache
    {
        private readonly ConcurrentDictionary<string, string> _cache = new ConcurrentDictionary<string, string>();
        private TimeSpan _expirationTime;
        private Timer _cleanupTimer;

        private bool _enabled;
        
        public GMLanMessageCache(int cleanupIntervalMs = 1000, int expirationMs = 3000)
        {
            _expirationTime = TimeSpan.FromMilliseconds(expirationMs);
            _cleanupTimer = new Timer(CleanCache, null, cleanupIntervalMs, cleanupIntervalMs);
            _enabled = true;
        }

        public bool UpdateInterval(int cleanupMs, int expirationMs)
        {
            _expirationTime = TimeSpan.FromMilliseconds(expirationMs);
            // Dispose of the old timer and create a new one
            _cleanupTimer?.Dispose();
            _cleanupTimer = new Timer(CleanCache, null, cleanupMs, cleanupMs);
            return true;
        }

        public bool IsUnique(GMLanMessage message)
        {
            if (!_enabled) return true; // might be confusing - if the cache is 'disabled' every message should be considered unique.
            var key = $"{message.Id}_{message.Data}";
            var timestamp = DateTime.UtcNow.Ticks.ToString();
            return _cache.TryAdd(key, timestamp);
        }

        public void Enable()
        {
            _enabled = true;
        }

        public void Disable()
        {
            _enabled = false;
        }

        private void CleanCache(object state)
        {
            var expirationTicks = DateTime.UtcNow.Subtract(_expirationTime).Ticks;
        
            foreach (var entry in _cache)
            {
                if (long.Parse(entry.Value) < expirationTicks)
                {
                    _cache.TryRemove(entry.Key, out _);
                }
            }
        }

        public void Dispose()
        {
            _cleanupTimer?.Dispose();
        }
    }
}