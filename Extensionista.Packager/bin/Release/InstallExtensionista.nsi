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
OutFile "OBN.EXT.Install.exe"

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
  
  WriteRegStr HKLM SOFTWARE\Extensionista\Extensionista "Install_Dir" "$INSTDIR"
  WriteRegStr HKLM SOFTWARE\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\Extensionista "" $INSTDIR
  ; write uninstall strings
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Extensionista" "DisplayName" "Extensionista (remove only)"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Extensionista" "UninstallString" '"$INSTDIR\ext-uninst.exe"'
  
  ; Put file there
  File Extensionista.dll
  File Extensionista.XML

  ; Create uninstaller
  WriteUninstaller "ext-uninst.exe"


SectionEnd ; end the section

Section "un.Uninstaller Section" ; uninstaller actions

	; Clean up
	DELETE $INSTDIR\ext-uninst.exe
	DELETE $INSTDIR\Extensionista.dll
	DELETE $INSTDIR\Extensionista.XML
	RMDir $INSTDIR
	DeleteRegKey HKLM SOFTWARE\Extensionista
	DeleteRegKey HKLM SOFTWARE\Microsoft\.NETFramework\v4.0.30319\AssemblyFoldersEx\Extensionista
	DeleteRegKey HKLM Software\Microsoft\Windows\CurrentVersion\Uninstall\Extensionista
	
SectionEnd

