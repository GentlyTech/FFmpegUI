Unicode true
SetCompressor /solid lzma

!include "MUI2.nsh"
!include "FileFunc.nsh"
!include "UserInfo.nsh"
!include "LogicLib.nsh"

!define NAME "Media Converter"
!define AUTHOR "Yep Development Studios"
!define VERSION "1.0.0.0"
!define PRIMARYEXE "MediaConverter.exe" ; For creating launch shortcuts to the main program
var StartMenuFolder

Function  .onInit
    Call IsUserAdmin
    Pop $R0
    !define InstalledAs $R0

    ${If} "${InstalledAs}" == "true" ; Is Admin
        SetShellVarContext all
        StrCpy $INSTDIR "$PROGRAMFILES\${NAME}"
    ${Else}
        SetShellVarContext current
        StrCpy $INSTDIR "$LOCALAPPDATA\${NAME}"
    ${EndIf}
    
    StrCpy $StartMenuFolder "$SMPROGRAMS\${NAME}"
FunctionEnd

name "${NAME}"
caption "${NAME} ${VERSION}"

RequestExecutionLevel user

!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\nsis3-install.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\nsis3-uninstall.ico"

!define MUI_ABORTWARNING
!define MUI_ABORTWARNING_TEXT "Are you sure you want to abort the installation? Any existing changes will be reverted and you will have to rerun the installer to complete the installation."

!define MUI_UNABORTWARNING
!define  MUI_UNABORTWARNING_TEXT "Are you sure you want to abort the uninstallation? The program will not be removed."

!define MUI_WELCOMEPAGE_TITLE "Welcome to the ${NAME} Setup Wizard."
!define MUI_WELCOMEPAGE_TEXT "The setup wizard will guide you through installing ${NAME} ${VERSION} on your computer.$\n$\nClick 'Next' to begin or 'Cancel' to exit the setup wizard."
!define MUI_WELCOMEFINISHPAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Wizard\nsis3-metro.bmp"
!insertmacro MUI_PAGE_WELCOME

!insertmacro MUI_PAGE_DIRECTORY
!define MUI_PAGE_HEADER_TEXT "Choose Install Location"
!define MUI_PAGE_HEADER_SUBTEXT "Choose the folder in which to install ${NAME}"

!define MUI_COMPONENTSPAGE_TEXT_DESCRIPTION_INFO "Hover over a component to learn more about what it does"
!define MUI_COMPONENTSPAGE_TEXT_DESCRIPTION_TITLE "Description"
!undef MUI_PAGE_HEADER_TEXT
!undef MUI_PAGE_HEADER_SUBTEXT
!define MUI_PAGE_HEADER_TEXT "Choose Install Components"
!define MUI_PAGE_HEADER_SUBTEXT "Select which components you would like to install"
!insertmacro MUI_PAGE_COMPONENTS

!insertmacro MUI_PAGE_INSTFILES

UninstallCaption "Uninstall ${NAME} ${VERSION}"
!define MUI_UNWELCOMEFINISHPAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Wizard\nsis3-metro.bmp"
!define MUI_WELCOMEPAGE_TITLE "Welcome to the ${NAME} Uninstallation Wizard."
!define MUI_WELCOMEPAGE_TEXT "The setup wizard will remove ${NAME} ${VERSION} from your computer.$\n$\nClick 'Next' to begin or 'Cancel' to abort the uninstall."
!insertmacro MUI_UNPAGE_WELCOME
!insertmacro MUI_UNPAGE_INSTFILES

!insertmacro MUI_LANGUAGE "English"

!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
!insertmacro MUI_DESCRIPTION_TEXT 0 "The program itself"
!insertmacro MUI_DESCRIPTION_TEXT 1 "Create a start menu folder containing shortcuts to the program and uninstaller"
!insertmacro MUI_DESCRIPTION_TEXT 2 "Adds a shortcut to the desktop for quick access"
!insertmacro MUI_FUNCTION_DESCRIPTION_END

Section "${NAME}" 0
   SectionIn "RO"
   CreateDirectory "$INSTDIR"
   SetOutPath "$INSTDIR"
   ${GetSize} "$INSTDIR" "/S=0K" $0 $1 $2
   IntFmt $0 "0x%08X" $0

   ${If} "${InstalledAs}" == "true" ; Is Admin
           WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" \
                            "DisplayName" "${NAME}"
            WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" \
                            "DisplayVersion" "${VERSION}"
            WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" \
                            "Publisher" "${AUTHOR}"
            WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" \
                            "UninstallString" "$INSTDIR\Uninstall.exe"
            WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" \
                            "DisplayIcon" "$INSTDIR\${PRIMARYEXE}"
            WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" \
                            "EstimatedSize" "$0"
    ${Else}
           WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" \
                            "DisplayName" "${NAME}"
            WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" \
                            "DisplayVersion" "${VERSION}"
            WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" \
                            "Publisher" "${AUTHOR}"
            WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" \
                            "UninstallString" "$INSTDIR\Uninstall.exe"
            WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" \
                            "DisplayIcon" "$INSTDIR\${PRIMARYEXE}"
            WriteRegDWORD HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" \
                            "EstimatedSize" "$0"
    ${EndIf}

   File "..\MediaConverter\bin\Debug\net5.0-windows\*"

   WriteUninstaller "$INSTDIR\Uninstall.exe"
SectionEnd

Section "Start Menu Entry" 1

    CreateDirectory $StartMenuFolder
    CreateShortcut "$StartMenuFolder\${NAME}.lnk" "$INSTDIR\${PRIMARYEXE}"
    CreateShortcut "$StartMenuFolder\Uninstall ${NAME}.lnk" "$INSTDIR\Uninstall.exe"
  
SectionEnd

Section "Desktop Shortcut" 2
      CreateShortcut "$DESKTOP\${NAME}.lnk" "$INSTDIR\${PRIMARYEXE}"
SectionEnd

Section "Uninstall"

    !define RequestExecutionLevel admin

    ${If} "${InstalledAs}" == "true" ; Is Admin
        SetShellVarContext all
        DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}"
    ${Else}
        SetShellVarContext current
        DeleteRegKey HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}"
    ${EndIf}

  Delete "$INSTDIR\*"

  Delete "$SMPROGRAMS\${NAME}\${NAME}.lnk"
  Delete "$SMPROGRAMS\${NAME}\Uninstall ${NAME}.lnk"
  Delete "$DESKTOP\${NAME}.lnk"

  RMDir "$INSTDIR"
  RMDir "$SMPROGRAMS\${NAME}"

SectionEnd