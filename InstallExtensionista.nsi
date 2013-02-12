; example1.nsi
;
; This script is perhaps one of the simplest NSIs you can make. All of the
; optional settings are left to their default settings. The installer simply 
; prompts the user asking them where to install, and drops a copy of example1.nsi
; there. 

;--------------------------------

; The name of the installer
Name "Extensionista"

; The file to write
OutFile "OBN_EXT_Install.exe"

; The default installation directory
InstallDir $PROGRAMFILES\ObliteracyDotNet\Extensionista

; Request application privileges for Windows Vista
RequestExecutionLevel admin

;--------------------------------

; Pages

Page directory
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles
;--------------------------------

; The stuff to install
Section "" ;No components page, name is not important

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  WriteRegStr HKLM SOFTWARE\ObliteracyDotNet.Extensionista\ObliteracyDotNet.Extensionista "Install_Dir" "$INSTDIR"

  ; write uninstall strings
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ObliteracyDotNet.Extensionista" "DisplayName" "Extensionista (remove only)"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\ObliteracyDotNet.Extensionista" "UninstallString" '"$INSTDIR\bt-uninst.exe"'
  
  ; Put file there
  File Extensionista.dll
  ; Install in GAC
  ExecWait '"$WINDIR\Microsoft.NET\Framework\"'
  ; Create uninstaller
  WriteUninstaller "bt-uninst.exe"
  
SectionEnd ; end the section

Section "un.Uninstaller Section" ; uninstaller actions
	;Uninstall from GAC
	ExecWait
	; Clean up
	DELETE $INSTDIR\bt-uninstall.exe
	DELETE $INSTDIR\Extensionista.dll
	RMDir $INSTDIR
	DeleteRegKey HKLM SOFTWARE\ObliteracyDotNet.Extensionista
	DeleteRegKey HKLM Software\Microsoft\Windows\CurrentVersion\Uninstall\ObliteracyDotNet.Extensionista
	
SectionEnd

