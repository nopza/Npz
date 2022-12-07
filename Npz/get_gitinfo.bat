@echo off
For /f "tokens=2-4 delims=/ " %%a in ('date /t') do (set mydate=%%c-%%a-%%b)
For /f "tokens=1-2 delims=/ " %%a in ('time /t') do (set mytime=%%a:%%b)

For /f "delims=" %%a in ('git rev-parse --abbrev-ref HEAD') do (set branchName=%%a)
For /f "delims=" %%a in ('git tag --contains') do (set tags=%%a)

echo Public Date: %mydate% %mytime% > git-info
echo Branch Name: %branchName% >> git-info
echo Tags: %tags% >> git-info
echo: >> git-info
echo == Commit Infomation == >> git-info
git show -s >> git-info
