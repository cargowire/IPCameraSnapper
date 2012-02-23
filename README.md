# IPCameraSnapper
A small console app that can be run in the background to continually retrieve and save snapshots from an IP camera.  For example to use with an updating image from a CCTV style camera.

## What is it?
The solution contains 2 projects.  One is a class library for the interaction with the camera and save stores (File system, FTP etc).  The other is a console application that utilises these in conjunction with a timer defined by the caller of the app.

## Usage
After ensuring that the appSettings section of the configuration file is correct with regard to the IP Cameras address and credentials:

C:\IPCameraSnapper\IPCameraSnapper.Console.exe 5 -- take a snapshot every 5 seconds
C:\IPCameraSnapper\IPCameraSnapper.Console.exe 20 -- take a snapshot every 20 seconds
C:\IPCameraSnapper\IPCameraSnapper.Console.exe -- take a single snapshot