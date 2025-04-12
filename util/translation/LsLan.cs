using System.Collections;
using System.Collections.Generic;

namespace GMLanDebug.util
{
    /**
     * Known translations for the low speed GMLan bus (33.3kbps - OBD-II Port Pin 1 and 5)
     */
    // https://docs.google.com/spreadsheets/d/1qEwOXSr3bWoc2VUhpuIam236OOZxPc2hxpLUsV0xkn0/edit?gid=1#gid=1 (amazing reference but incomplete/outdated)
    
    public class LsLan
    {
        private static readonly List<GMLanMapping> Translations = new List<GMLanMapping>();

        public static void Init()
        {
            PopulateTranslations();
        }

        public static string GetMappedName(string header)
        {
            foreach (var translation in Translations)
            {
                if (translation.Header.Equals(header)) return translation.Name;
            }

            return null;
        }

        private static void PopulateTranslations()
        {
            Translations.Add(new GMLanMapping("100020", "SYSTEM_POWER_MODE"));
            Translations.Add(new GMLanMapping("100040", "SYSTEM_POWER_MODE_BACKUP"));
            Translations.Add(new GMLanMapping("100060", "EASY_KEY_DISPLAY_COMMANDS"));
            Translations.Add(new GMLanMapping("80080", "RFA_FUNCTION"));
            Translations.Add(new GMLanMapping("1000A0", "TIRE_PRESSURE_STATUS_LS"));
            Translations.Add(new GMLanMapping("1000C0", "MODULE_SUBSTITUTION_STATUS"));
            Translations.Add(new GMLanMapping("100", "ROLLOVER_STATUS"));
            Translations.Add(new GMLanMapping("100120", "INFOTAINMENT_OPERATION_ALLOWED"));
            Translations.Add(new GMLanMapping("100140", "TPM_DISPLAY_COMMANDS"));
            Translations.Add(new GMLanMapping("100160", "PLATFORM_IMMOBILIZER_DATA"));
            Translations.Add(new GMLanMapping("100180", "PLATFORM_IMMOBILIZER_PASSWORD"));
            Translations.Add(new GMLanMapping("1001A0", "VEH_SECURITY_DISPLAY_COMMANDS"));
            Translations.Add(new GMLanMapping("1001C0", "POWERTRAIN_IMMOBILIZER_DATA"));
            Translations.Add(new GMLanMapping("1001E0", "CHIME_COMMAND"));
            Translations.Add(new GMLanMapping("100200", "CHIME_STATUS"));
            Translations.Add(new GMLanMapping("100220", "DIMMING_INFORMATION"));
            Translations.Add(new GMLanMapping("100240", "VIN_DIGITS_2_TO_9"));
            Translations.Add(new GMLanMapping("100260", "VIN_DIGITS_10_TO_17"));
            Translations.Add(new GMLanMapping("100280", "HS_DEVICE_INFORMATION"));
            Translations.Add(new GMLanMapping("0002C0", "AUTO_OCCUPANT_SENSING_ENABLED"));
            Translations.Add(new GMLanMapping("1002E0", "DISPLAY_MEASUREMENT_SYSTEM"));
            Translations.Add(new GMLanMapping("100300", "BATTERY_VOLTAGE"));
            Translations.Add(new GMLanMapping("320", "ROLLOVER_SENSING_ENABLED"));
            Translations.Add(new GMLanMapping("100360", "DRIVER_DOOR_STATUS"));
            Translations.Add(new GMLanMapping("100380", "PASSENGER_DOOR_STATUS"));
            Translations.Add(new GMLanMapping("1003A0", "LEFT_REAR_DOOR_STATUS"));
            Translations.Add(new GMLanMapping("1003C0", "RIGHT_REAR_DOOR_STATUS"));
            Translations.Add(new GMLanMapping("1003E0", "PERS_LIGHT_LOCK_STATUS"));
            Translations.Add(new GMLanMapping("100400", "PERS_LIGHT_LOCK_REQUEST"));
            Translations.Add(new GMLanMapping("100420", "LIGHTING_STATUS"));
            Translations.Add(new GMLanMapping("100440", "ENHANCED_SERVICES_REQUEST"));
            Translations.Add(new GMLanMapping("100460", "PROGRAMMING_EVENT_REQUESTS"));
            Translations.Add(new GMLanMapping("100480", "EXPORT_MODULE_STATUS"));
            Translations.Add(new GMLanMapping("1004A0", "TRANSMISSION_GEAR_INFORMATION"));
            Translations.Add(new GMLanMapping("1004C0", "FUEL_INFORMATION"));
            Translations.Add(new GMLanMapping("1004E0", "VEHICLE_ODO_BRK_WASH_LEVEL"));
            Translations.Add(new GMLanMapping("100500", "VEHICLE_SPEED_INFORMATION"));
            Translations.Add(new GMLanMapping("100520", "ENGINE_INFORMATION_1"));
            Translations.Add(new GMLanMapping("100540", "AUTO_HIGH_BEAM_STATUS"));
            Translations.Add(new GMLanMapping("100560", "DOOR_LOCK_COMMAND"));
            Translations.Add(new GMLanMapping("100580", "DRIVER_DOOR_LOCK_SWITCH_STATUS"));
            Translations.Add(new GMLanMapping("1005A0", "PASS_DOOR_LOCK_SWITCH_STATUS"));
            Translations.Add(new GMLanMapping("1005E0", "BRAKE_AND_CRUISE_CONTROL_STATUS"));
            Translations.Add(new GMLanMapping("100600", "REAR_CLOSURE_STATUS"));
            Translations.Add(new GMLanMapping("100640", "ENGINE_INFORMATION_3"));
            Translations.Add(new GMLanMapping("1006E0", "ENGINE_INFORMATION_2"));
            Translations.Add(new GMLanMapping("100700", "REMOTE_START_STATUS"));
            Translations.Add(new GMLanMapping("100720", "REAR_CLOSURE_RELEASE_SWITCH"));
            Translations.Add(new GMLanMapping("780", "MEMORY_SWITCH_STATUS"));
            Translations.Add(new GMLanMapping("0407A0", "OCCUPANT_PROTECTION_SYCH"));
            Translations.Add(new GMLanMapping("100800", "WINDOW_MOTION_REQUEST"));
            Translations.Add(new GMLanMapping("820", "MIRROR_MOVEMENT_REQUEST"));
            Translations.Add(new GMLanMapping("100840", "PERS_DRIVER_POSITION_STATUS"));
            Translations.Add(new GMLanMapping("100860", "PERS_DRIVER_POSITION_REQUEST"));
            Translations.Add(new GMLanMapping("100880", "PERS_CHIME_STATUS"));
            Translations.Add(new GMLanMapping("1008A0", "PERS_CHIME_REQUEST"));
            Translations.Add(new GMLanMapping("100900", "ROLLOVER_SENSOR_IDENTIFIER"));
            Translations.Add(new GMLanMapping("100940", "AUTO_OCCUPANT_SENSOR_IDENTIFIER"));
            Translations.Add(new GMLanMapping("080A00", "DRIVER_IDENTIFIER_LS"));
            Translations.Add(new GMLanMapping("100A20", "LEVELING_AND_SUSPENSION_STATUS"));
            Translations.Add(new GMLanMapping("100A60", "GPS_DATE_AND_TIME"));
            Translations.Add(new GMLanMapping("100A80", "TIME_OF_DAY"));
            Translations.Add(new GMLanMapping("100AA0", "GPS_GEOGRAPHICAL_POSITION"));
            Translations.Add(new GMLanMapping("100AC0", "GPS_ELEVATION_AND_HEADING"));
            Translations.Add(new GMLanMapping("100B00", "REAR_SEATBELT_STATUS"));
            Translations.Add(new GMLanMapping("0C0B60", "STEERING_WHEEL_ANGLE"));
            Translations.Add(new GMLanMapping("100C00", "CLIMATE_CONTROL"));
            Translations.Add(new GMLanMapping("100C20", "OUTSIDE_AIR_TEMP_CORRECTED"));
            Translations.Add(new GMLanMapping("100C40", "ANTILOCK_BRAKE_AND_TC_STATUS"));
            Translations.Add(new GMLanMapping("100C80", "CLIMATE_CONTROL_GENERAL_STATUS_2"));
            Translations.Add(new GMLanMapping("100D00", "STEERING_WHEEL_CONTROL_SWITCHES"));
            Translations.Add(new GMLanMapping("0C0D40", "REAR_CLIMATE_CONTROL_STATUS"));
            Translations.Add(new GMLanMapping("100D60", "RR_CLIMATE_CONTROL_RMT_COMMAND"));
            Translations.Add(new GMLanMapping("000DA0", "HEAD_UP_DISPLAY_STATUS"));
            Translations.Add(new GMLanMapping("100E00", "ALARM_CLOCK_STATUS_LS"));
            Translations.Add(new GMLanMapping("100E20", "CLIMATE_CONTROL_BUTTONS"));
            Translations.Add(new GMLanMapping("100E40", "LEFT_CLIMATE_CONTROL_TEMP_DIAL"));
            Translations.Add(new GMLanMapping("100E60", "RIGHT_CLIMATE_CONTROL_TEMP_DIAL"));
            Translations.Add(new GMLanMapping("100EA0", "CLIMATE_CONTROL_EXTENDED_STATUS"));
            Translations.Add(new GMLanMapping("101160", "PERS_PARKING_ASSIST_REQ"));
            Translations.Add(new GMLanMapping("101180", "PERS_PARKING_ASSIST_STATUS"));
            Translations.Add(new GMLanMapping("1011A0", "PARKING_ASSISTANCE_STATUS"));
            Translations.Add(new GMLanMapping("1011C0", "PARK_ASSIST_REAR_DISTANCE"));
            Translations.Add(new GMLanMapping("1011E0", "PARK_ASSIST_FRONT_DISTANCE"));
            Translations.Add(new GMLanMapping("1200", "AIRBAG_IMPACT_DATA"));
            Translations.Add(new GMLanMapping("1280", "AIRBAG_IMPACT_DATA_1"));
            Translations.Add(new GMLanMapping("0012A0", "AIRBAG_IMPACT_DATA_2"));
            Translations.Add(new GMLanMapping("0012C0", "AIRBAG_IMPACT_DATA_3"));
            Translations.Add(new GMLanMapping("0012E0", "AIRBAG_IMPACT_DATA_4"));
            Translations.Add(new GMLanMapping("1300", "AIRBAG_INDICATIONS"));
            Translations.Add(new GMLanMapping("1320", "MEMORY_RECALL_IMPACT_DISABLE"));
            Translations.Add(new GMLanMapping("101340", "ENG_TRANS_OIL_LIFE_RESET_REQ"));
            Translations.Add(new GMLanMapping("101380", "AOS_CONNECTION"));
            Translations.Add(new GMLanMapping("1013A0", "DIGITAL_AUDIO_RECEIVER_STATUS"));
            Translations.Add(new GMLanMapping("1013C0", "REAR_SEAT_ENTERTAINMENT_STATUS"));
            Translations.Add(new GMLanMapping("101400", "PERS_MIRROR_TILT_STATUS"));
            Translations.Add(new GMLanMapping("101420", "PERS_MIRROR_TILT_REQ"));
            Translations.Add(new GMLanMapping("101440", "PERS_WINDOW_LOCKOUT_STATUS"));
            Translations.Add(new GMLanMapping("101460", "PERS_WINDOW_LOCKOUT_REQ"));
            Translations.Add(new GMLanMapping("101480", "PERSONALIZATION_INFORMATION"));
            Translations.Add(new GMLanMapping("102400", "PHONE_STATUS"));
            Translations.Add(new GMLanMapping("102480", "ADAPTIVE_CRUISE_DISPLAY"));
            Translations.Add(new GMLanMapping("102540", "CONTENT_THEFT_SENSOR_DISABLE_REQ"));
            Translations.Add(new GMLanMapping("82600", "CONTENT_THEFT_SENSOR_STATUS"));
            Translations.Add(new GMLanMapping("142800", "SOD_LEFT_STATUS"));
            Translations.Add(new GMLanMapping("102820", "AUDIO_MASTER_AMPLIFIER_COMMAND"));
            Translations.Add(new GMLanMapping("102840", "AUDIO_MASTER_AMPLIFIER_SETTING"));
            Translations.Add(new GMLanMapping("102860", "AUDIO_MASTER_AMPLIFIER_MUTE"));
            Translations.Add(new GMLanMapping("142880", "SOD_RIGHT_STATUS"));
            Translations.Add(new GMLanMapping("1028A0", "AUDIO_MASTER_ARBITRATION_COMMAND"));
            Translations.Add(new GMLanMapping("1028C0", "PHONE_DIAL_COMMAND_1"));
            Translations.Add(new GMLanMapping("1028E0", "PHONE_DIAL_COMMAND_2"));
            Translations.Add(new GMLanMapping("102900", "AUXILIARY_NAV_DATA_DISPLAY"));
            Translations.Add(new GMLanMapping("102920", "AUDIO_MASTER_AMPLIFIER_CONTROL"));
            Translations.Add(new GMLanMapping("102940", "REMOTE_CHANGER_COMMAND"));
            Translations.Add(new GMLanMapping("102960", "ADVANCED_REMOTE_RECEIVER_CONTROL"));
            Translations.Add(new GMLanMapping("102980", "VOICE_RECOGNITION_STATUS"));
            Translations.Add(new GMLanMapping("102A00", "DRIVER_SEAT_TEMP_CONTROL"));
            Translations.Add(new GMLanMapping("102A20", "DRIVER_SEAT_TEMP_INDICATION"));
            Translations.Add(new GMLanMapping("102A40", "PASS_SEAT_TEMP_CONTROL"));
            Translations.Add(new GMLanMapping("102A60", "PASS_SEAT_TEMP_INDICATION"));
            Translations.Add(new GMLanMapping("102A80", "RR_LEFT_SEAT_TEMP_CONTROL"));
            Translations.Add(new GMLanMapping("102AA0", "RR_LEFT_SEAT_TEMP_INDICATION"));
            Translations.Add(new GMLanMapping("102AC0", "RR_RIGHT_SEAT_TEMP_CONTROL"));
            Translations.Add(new GMLanMapping("102AE0", "RR_RIGHT_SEAT_TEMP_INDICATION"));
            Translations.Add(new GMLanMapping("102C00", "MEMORY_COMMAND"));
            Translations.Add(new GMLanMapping("0C2D00", "DRIVER_MIRROR_MOTION"));
            Translations.Add(new GMLanMapping("0C2D20", "PASENGER_MIRROR_MOTION"));
            Translations.Add(new GMLanMapping("103000", "ARB_TEXT_DISPLAY_GEN_ATTRIBUTES"));
            Translations.Add(new GMLanMapping("103020", "ARB_TEXT_DISPLAY_LINE_ATTRIBUTES"));
            Translations.Add(new GMLanMapping("103040", "ARB_TEXT_REQ_SET_DISP_ICON"));
            Translations.Add(new GMLanMapping("103060", "ARB_TEXT_DISPLAY_STATUS"));
            Translations.Add(new GMLanMapping("103080", "ARB_TEXT_DISPLAY_MENU_ACTION"));
            Translations.Add(new GMLanMapping("1030A0", "ARB_TEXT_REQ_SET_DISP_PARAMETERS"));
            Translations.Add(new GMLanMapping("1030C0", "ARB_TEXT_REQ_SET_DISPLAY_TEXT"));
            Translations.Add(new GMLanMapping("1030E0", "ARB_TEXT_REQ_DOWNLOAD_ICON_DATA"));
            Translations.Add(new GMLanMapping("103100", "REAR_SEAT_AUDIO_STATUS"));
            Translations.Add(new GMLanMapping("103120", "AUDIO_AMPLIFIER_STATUS"));
            Translations.Add(new GMLanMapping("103140", "REAR_SEAT_AUDIO_COMMAND_1"));
            Translations.Add(new GMLanMapping("103160", "REMOTE_CHANGER_STATUS"));
            Translations.Add(new GMLanMapping("103180", "REMOTE_CHANGER_MEDIA_STATUS"));
            Translations.Add(new GMLanMapping("1031A0", "RSE_HEADPHONE_AUDIO_STATUS"));
            Translations.Add(new GMLanMapping("1031C0", "AUDIO_SOURCE_STATUS"));
            Translations.Add(new GMLanMapping("1031E0", "REMOTE_RECEIVER_STATUS"));
            Translations.Add(new GMLanMapping("103200", "ARB_TEXT_DISPLAY_ICON_ATTRIBUTES"));
            Translations.Add(new GMLanMapping("103220", "VIDEO_SOURCE_DEVICE_STATUS"));
            Translations.Add(new GMLanMapping("103240", "REMOTE_RECEIVER_CHANNEL_STATUS"));
            Translations.Add(new GMLanMapping("103260", "REMOTE_RECEIVER_PRESET_INFO"));
            Translations.Add(new GMLanMapping("103280", "REMOTE_RECEIVER_STATUS_2"));
            Translations.Add(new GMLanMapping("1032A0", "TV_TUNER_STATUS"));
            Translations.Add(new GMLanMapping("1032C0", "VIDEO_MASTER_ARB_COMMAND"));
            Translations.Add(new GMLanMapping("1032E0", "REMOTE_RECEIVER_TV_STATION"));
            Translations.Add(new GMLanMapping("103300", "REMOTE_RECEIVER_CONTROL"));
            Translations.Add(new GMLanMapping("103600", "ONSTAR_VOICE_PROMPT_REQUEST"));
            Translations.Add(new GMLanMapping("103620", "ONSTAR_MIN_DIGITS_1_15"));
            Translations.Add(new GMLanMapping("103640", "ONSTAR_MIN_DIGITS_16_30"));
            Translations.Add(new GMLanMapping("103660", "ONSTAR_VOICE_PROMPT_STATUS"));
            Translations.Add(new GMLanMapping("103E00", "COLUMN_LOCK_COMMAND"));
            Translations.Add(new GMLanMapping("104000", "COLUMN_LOCK_STATUS"));
            Translations.Add(new GMLanMapping("104F00", "AIR_CONDITIONING_CONTROL"));
            Translations.Add(new GMLanMapping("10EC40", "VIN_DIGITS_2_TO_9_ALT"));
            Translations.Add(new GMLanMapping("10EC80", "VIN_DIGITS_10_TO_17_ALT"));
            Translations.Add(new GMLanMapping("110040", "ALARM_CLOCK_REQUEST_2"));
            Translations.Add(new GMLanMapping("0FFFE0", "BROADCAST_PRESENCE"));
        }
    }
}