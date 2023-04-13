@ECHO OFF
ECHO Demo Automation Executed Started.

set testcategory=Login
set dllpath=C:\Users\imammami\source\repos\Playwright_BootCamp_001\Playwright_BootCamp_001\bin\Debug\net6.0\Playwright_BootCamp_001.dll
set trxerpath=C:\Users\imammami\source\repos\Playwright_BootCamp_001\Resources\
set testsummaryreportPath=C:\Users\imammami\source\repos\Playwright_BootCamp_001\Resources\TestSummaryReport\

FOR /f %%a IN ('WMIC OS GET LocalDateTime ^| FIND "."') DO SET DTS=%%a
SET filename=%testcategory%_%DTS:~0,4%%DTS:~4,2%%DTS:~6,2%%DTS:~8,2%%DTS:~10,2%%DTS:~12,2%
echo %filename%

call "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\Tools\VsDevCmd.bat"
cd %testsummaryreportPath%


VSTest.Console.exe  %dllpath% /TestCaseFilter:"TestCategory=%testcategory%" /Logger:"trx;LogFileName=%testsummaryreportPath%\%filename%\%filename%.trx"

cd %trxerpath%
TrxToHTML.exe %testsummaryreportPath%%filename%\

PAUSE