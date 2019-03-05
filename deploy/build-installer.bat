call "C:\Program Files (x86)\Microsoft Visual Studio 14.0\VC\vcvarsall.bat" x64
ISCC.exe installer.iss
signtool.exe sign  -t http://timestamp.globalsign.com/scripts/timestamp.dll  -fd SHA256 -v Output\InstallKuesaFor3DSMax.exe