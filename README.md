# Kuesa 3dsmax Plugins

This repository contains a number of projects to build plugins for adding Kuesa related features to 3dsmax

It is composed to 2 main parts:
- a plugin to edit and manage layers which can be manipulated in Qt 3D
- a glTF exporter, based on BabylonJS, adding a few features specific to Kuesa
  (such as wireframe export and layer handling)
  Note: Exporting wireframes is currently limited to tri faces.

# Building

## Requirements
* Visual Studio 2017
* .NET Framework 4.7 development tool
* Windows 10 SDK (10.0.10586.0)
* VC++ 2015.3 v14.00 (v140) toolset for desktop
* 3dsmax 2019
* 3dsmax SDK 2019

## Environment Variables
Please set the following environment variables, adjusting paths to match your installation:
`ADSK_3DSMAX_SDK_2019=C:\Program Files\Autodesk\3ds Max 2019`
`ADSK_3DSMAX_x64_2019=C:\Program Files\Autodesk\3ds Max 2019 SDK`
`MaxSdkLib=%ADSK_3DSMAX_x64_2019%\maxsdk\lib\x64\Release`

## Building
* Open Visual Studio, as administrator
* Open `KuesaPlugins.sln`
* If prompted, make sure is used `v140` build tools and `10.0.10586.0` SDK

