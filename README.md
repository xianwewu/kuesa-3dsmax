# Kuesa 3ds Max Plugins

This repository contains a number of projects to build plugins for adding Kuesa related features to 3ds Max

It is composed to 2 main parts:
- a plugin to edit and manage layers which can be manipulated in Qt 3D
- a glTF exporter, based on BabylonJS, adding a few features specific to Kuesa
  (such as wireframe export and layer handling)
  Note: Exporting wireframes is currently limited to tri faces.

# Installing

To install pre-built versions of the Kuesa plugins, please 
download `InstallKuesaFor3DSMax-latest.exe` from http://bit.ly/KuesaFor3DSMax
and run the installer.

The plugins will be installed but 3ds Max will only be configured for the user
running the installer.

Other users on the system should follow the post-installation instructions
provided with the installer.

# Building

## Requirements
* Visual Studio 2017
* .NET Framework 4.7 development tool
* Windows 10 SDK (10.0.10586.0)
* VC++ 2015.3 v14.00 (v140) toolset for desktop
* 3ds Max 2019
* 3ds Max SDK 2019

## Environment Variables
If the 3ds Max installer has not done it automatically, please set the following
environment variables, adjusting paths to match your installation:
`ADSK_3DSMAX_SDK_2019=C:\Program Files\Autodesk\3ds Max 2019`
`ADSK_3DSMAX_x64_2019=C:\Program Files\Autodesk\3ds Max 2019 SDK`
`MaxSdkLib=%ADSK_3DSMAX_x64_2019%\maxsdk\lib\x64\Release`

## Building
* Open Visual Studio, as administrator
* Open `KuesaPlugins.sln`
* If prompted, make sure is used `v140` build tools and `10.0.10586.0` SDK
* Build 'Max2Babylon2019'. This will build the exporter and install it directly to 3ds Max.
* Build 'KuesaLayers'. This will build the Kuesa Layers Manager into a subfolder of the deploy folder.

## Installing Kuesa Plugins For 3DS Max

After building your own copy of the plugins, 3ds Max needs to be configured to use the latest versions.
You do not need to do this if you are using the pre-built versions as describe above.

* Build both projects as explained above
* In 3DS Max under 'Customize' choose 'Cofigure System Paths...'
* Choose '3rd Party Plug-Ins' tab
* Click 'Add...' and choose '...deploy/Kuesa/' (part of this repo)
* Restart 3DS Max!
* You'll find the Kuesa plugins in the main menu under 'Kuesa'
