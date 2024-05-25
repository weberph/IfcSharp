@ECHO OFF

SET EXTERNAL_DIR=%~dp0_external

IF EXIST "%EXTERNAL_DIR%" (
  echo _external directory exists already: aborted
  exit /b 1
)

where git.exe 1>NUL 2>NUL
IF errorlevel 1 (
  echo git not found - add git to PATH
  exit /b 1
)

where cmake.exe 1>NUL 2>NUL
IF errorlevel 1 (
  echo cmake not found - add cmake to PATH
  exit /b 1
)

where cl.exe 1>NUL 2>NUL
IF errorlevel 1 (
  echo cl not found - use a Visual Studio developer command prompt
  exit /b 1
)

SET IFC_REPO=%EXTERNAL_DIR%\ifc

mkdir "%EXTERNAL_DIR%"

@ECHO ON

git clone https://github.com/microsoft/ifc.git "%IFC_REPO%"
git -C "%IFC_REPO%" checkout 1a422d292d756b99b364ffa0919ed970d8b1c6ac

pushd "%IFC_REPO%"

vcpkg x-update-baseline --add-initial-baseline
cmake --preset=test-msvc

@ECHO OFF

popd
