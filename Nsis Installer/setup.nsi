## needs https://nsis.sourceforge.io/ShellExecAsUser_plug-in

!define PRODUCT_NAME "PDF-Merger"
!define PRODUCT_COMPANY "Patrick Hagelkruys"
!define PRODUCT_WEB_SITE "https://github.com/Hagelkruys/PdfMerger"
!define PRODUCT_NAME_PATH "PDFMerger"
!define PRODUCT_DIR_REGKEY "Software\${PRODUCT_NAME_PATH}"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_VERSION "1.3.0.0"


!define FILE_EXT ".pdfmerger"
!define FILE_EXT_2 ".zpdfmerger"

!define FILE_TYPE "PdfMerger.Project"
!define FILE_DESC "PDF Merger Project File"



VIAddVersionKey "ProductName" "${PRODUCT_NAME}"
VIAddVersionKey "CompanyName" "${PRODUCT_COMPANY}"
VIAddVersionKey "FileVersion" "${PRODUCT_VERSION}"
VIAddVersionKey "FileDescription" ""
VIAddVersionKey "LegalCopyright" ""
VIProductVersion "${PRODUCT_VERSION}"

SetCompressor /FINAL /SOLID lzma





!include "MUI.nsh"
!include LogicLib.nsh
!include WinMessages.nsh
!include FileFunc.nsh
!insertmacro GetParameters

; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "AppIcon.ico"
!define MUI_UNICON "AppIcon.ico"



; Welcome page
!define MUI_WELCOMEPAGE_TITLE 'Welcome to the installation of ${PRODUCT_NAME} ${PRODUCT_VERSION}'
!define MUI_WELCOMEPAGE_TITLE_3LINES
!insertmacro MUI_PAGE_WELCOME
; License page
!insertmacro MUI_PAGE_LICENSE "license.txt"
; Directory page
!insertmacro MUI_PAGE_DIRECTORY
; Instfiles page
!insertmacro MUI_PAGE_INSTFILES
; Finish page
!define MUI_FINISHPAGE_TITLE_3LINES
!define MUI_FINISHPAGE_RUN
!define MUI_FINISHPAGE_RUN_FUNCTION ExecAppFile
!insertmacro MUI_PAGE_FINISH
; Uninstaller pages
!insertmacro MUI_UNPAGE_INSTFILES
; Language files
!insertmacro MUI_LANGUAGE "English"

; Reserve files
!insertmacro MUI_RESERVEFILE_INSTALLOPTIONS
!insertmacro MUI_RESERVEFILE_LANGDLL

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "PDFMerger_v${PRODUCT_VERSION}_Setup.exe"


InstallDir "$PROGRAMFILES\${PRODUCT_NAME_PATH}"
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
ShowInstDetails show
ShowUnInstDetails show

RequestExecutionLevel admin 


Function .onInit   

	System::Call 'kernel32::CreateMutexA(i 0, i 0, t "PDFMergerMutex") i .r1 ?e'
	Pop $R0
	StrCmp $R0 0 AfterRunCheck

	IfSilent +2
		MessageBox MB_OK|MB_ICONEXCLAMATION "The installation is already running."	
	Abort  
		
AfterRunCheck:
  
	var /GLOBAL cmdLineParams
	${GetParameters} $cmdLineParams	
	
	ClearErrors
	
	Call UninstallPrevious
FunctionEnd



Section "mainprogram" SEC01

	SetOverwrite on
	
	SetOutPath "$INSTDIR"	
	
	File /r "files\*"

	SetShellVarContext all
		CreateDirectory "$SMPROGRAMS\${PRODUCT_NAME}\"
		CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\${PRODUCT_NAME}.lnk" "$INSTDIR\PDFMerger.exe"
		CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}\Uninstall.lnk" "$INSTDIR\uninst.exe"
	SetShellVarContext current 	
	
	; --- Register file extension ---
    WriteRegStr HKCR "${FILE_EXT}" "" "${FILE_TYPE}"
	WriteRegStr HKCR "${FILE_EXT_2}" "" "${FILE_TYPE}"
	
    WriteRegStr HKCR "${FILE_TYPE}" "" "${FILE_DESC}"
    WriteRegStr HKCR "${FILE_TYPE}\DefaultIcon" "" "$INSTDIR\PDFMerger.exe,0"
	WriteRegStr HKCR "${FILE_TYPE}\shell\open" "FriendlyAppName" ${PRODUCT_NAME}
    WriteRegStr HKCR "${FILE_TYPE}\Shell\Open\Command" "" '"$INSTDIR\PDFMerger.exe" "%1"'
	WriteRegDWORD HKCR "${FILE_TYPE}\Shell\Open\DropTarget" "Clsid" 0
	
    
	
	System::Call 'shell32::SHChangeNotify(i 0x08000000, i 0, i 0, i 0)' ; Refresh shell

SectionEnd

Section -Post
	WriteUninstaller "$INSTDIR\uninst.exe"
	StrCpy $0 "$INSTDIR\install.log"
	Push $0
SectionEnd

Function ExecAppFile
	ShellExecAsUser::ShellExecAsUser "" "$INSTDIR\PDFMerger.exe"
FunctionEnd



Function un.onInit
	var /GLOBAL UnCmdLineParams
    ${un.GetParameters} $UnCmdLineParams
    ClearErrors
FunctionEnd


Section Uninstall
	Delete "$INSTDIR\*.*"
	Delete "$SMPROGRAMS\${PRODUCT_NAME}\*.*"
	RMDir /r "$SMPROGRAMS\${PRODUCT_NAME}"

    ; --- Remove file association ---
	DeleteRegKey HKCR "${FILE_TYPE}\Shell\Open\DropTarget"
    DeleteRegKey HKCR "${FILE_TYPE}\Shell\Open\Command"
    DeleteRegKey HKCR "${FILE_TYPE}\DefaultIcon"
    DeleteRegKey HKCR "${FILE_TYPE}"
    DeleteRegKey HKCR "${FILE_EXT}"
    DeleteRegKey HKCR "${FILE_EXT_2}"
	
	
	System::Call 'shell32::SHChangeNotify(i 0x08000000, i 0, i 0, i 0)' ; Refresh shell

	SetAutoClose true
SectionEnd

Function un.onUninstSuccess
  HideWindow
  IfSilent +2
    MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) successfully uninstalled."
FunctionEnd




Function UninstallPrevious
    ReadRegStr $R0 HKLM "${PRODUCT_UNINST_KEY}" "UninstallString"
    StrCmp $R0 "" done
    
	IfSilent suninst ;if silent goto suninst
  
		MessageBox MB_OKCANCEL|MB_ICONEXCLAMATION \
		"A version of ${PRODUCT_NAME} is already installed. $\n$\n `OK` to uninstall the \
		existing version." IDOK suninst
		Abort
  	
	;Run the uninstaller
	suninst:
		ClearErrors
		;;ExecWait '$R0 _?=$INSTDIR ' ;Do not copy the uninstaller to a temp file
        ExecWait '$R0 /S _?=$INSTDIR' 
		Goto done ;End here	
		
	done:
FunctionEnd
