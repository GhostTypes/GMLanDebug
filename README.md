# GMLanDebug

## Overview
- GMLanDebug is a C# tool designed to connect to an Arduino over serial to decode/debug GMLan canbus traffic
- Something like the MCP2515 is suitable, although any device capable of reading GMLan messages from OBD-II will work.
- Wiring and pinouts for accessing the high/low speed GMLan bus can be found online with ease


## Features
- Display detailed GMLan traffic from many GM vehicles in real-time , assisting with reverse-engineering and live-testing
- Decode messages from known IDs (WIP) into human-readable format, as well as automatic decimal & ascii conversion
<br>

Handling high volume of canbus traffic 

![image](https://github.com/user-attachments/assets/cb1c8ebe-45cc-4d0a-92ca-a9e3e7ec013e)

UI Overview

<img width="1034" alt="yes" src="https://github.com/user-attachments/assets/38858ce3-03fc-4172-a649-22075303f32e" />

Decoding data from a known id - date and time from the vehicle

![IMG20241221140906](https://github.com/user-attachments/assets/0ec2589c-2ea1-4339-a51e-15694519845d)


# References
- [GMLanBible](https://is.gd/gmlanbible)  (huge amount of helpful information)
- [Doc88 Downloader](https://github.com/apankowski/doc88-downloader) (downloading *totally legit* PDFs about GMLan stuff)
- [pcmhacking](https://pcmhacking.net/) (tons of helpful information)
