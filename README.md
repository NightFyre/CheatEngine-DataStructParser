# CheatEngine-DataStructParser

| Original                                                                                                         |   Parsed Class                                                                                               |  
| :------------------------------------------------------------------------------------------------------------: | :-------------------------------------------------------------------------------------------------------------: |  
| ![image](https://user-images.githubusercontent.com/80198020/204425068-0ab9e069-9439-453a-a420-c7117d181d32.png) | ![image](https://user-images.githubusercontent.com/80198020/204425105-26d8ad17-b327-4bb1-9b3a-e446e117858a.png) |
## How-To-Use  
- Dump an Unreal Engine Game with eiether CakeSan or GH CheatEngine Plugins
- Dissect data structures to get the class you want
- Copy the contents of the whole window
- Paste the contents into "DataStructParser"
- Input a name for the class and press "Parse XML to C++ Class"

Example XML Input Data retrieved via GuidedHacking / CakeSan UnrealEngine Plugins  
The following can be obtained by copying the Data Structure Field in CheatEngine *see screenshot*  
```xml
<Elements>
  <Element Offset="48" Vartype="Pointer" Bytesize="8" OffsetHex="00000030" Description="PlayerController" DisplayMethod="unsigned integer"/>
  <Element Offset="56" Vartype="4 Bytes" Bytesize="4" OffsetHex="00000038" Description="CurrentNetSpeed" DisplayMethod="unsigned integer"/>
  <Element Offset="60" Vartype="4 Bytes" Bytesize="4" OffsetHex="0000003C" Description="ConfiguredInternetSpeed" DisplayMethod="unsigned integer"/>
  <Element Offset="64" Vartype="4 Bytes" Bytesize="4" OffsetHex="00000040" Description="ConfiguredLanSpeed" DisplayMethod="unsigned integer"/>
  <Element Offset="88" Vartype="Pointer" Bytesize="8" OffsetHex="00000058" Description="ViewportClient" DisplayMethod="unsigned integer"/>
  <Element Offset="124" Vartype="Byte" Bytesize="1" OffsetHex="0000007C" Description="AspectRatioAxisConstraint" DisplayMethod="unsigned integer"/>
  <Element Offset="128" Vartype="Pointer" Bytesize="8" OffsetHex="00000080" Description="PendingLevelPlayerControllerClass" DisplayMethod="unsigned integer"/>
  <Element Offset="136" Vartype="Byte" Bytesize="1" OffsetHex="00000088" Description="bSentSplitJoin[1]" DisplayMethod="unsigned integer"/>
</Elements>
```

<p align="center">
<img src="https://user-images.githubusercontent.com/80198020/204420777-587e0e0a-fccf-4411-ad94-11d61273159c.png">
</p>

**Output Result**
```c++
class LocalPlayer {
   PlayerController* PlayerController;  //  0x00000030
   int32_t CurrentNetSpeed;  //  0x00000038
   int32_t ConfiguredInternetSpeed;  //  0x0000003C
   int32_t ConfiguredLanSpeed;  //  0x00000040
   ViewportClient* ViewportClient;  //  0x00000058
   unsigned char AspectRatioAxisConstraint;  //  0x0000007C
   PendingLevelPlayerControllerClass* PendingLevelPlayerControllerClass;  //  0x00000080
   unsigned char bSentSplitJoin[1];  //  0x00000088
};
```
