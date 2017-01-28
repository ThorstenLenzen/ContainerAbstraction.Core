
echo ******************************************************************
echo ** Copy TestAssmblies to to output folder to avoid referencing. **
echo ******************************************************************

xcopy /y %1\..\assemblies\TestContrcat\bin\Debug\netstandard1.6\TestContrcat.dll %2
xcopy /y %1\..\assemblies\TestType\bin\Debug\netstandard1.6\TestType.dll %2