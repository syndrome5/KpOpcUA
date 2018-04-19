# KpOpcUA

Plugin OPC UA protocol for RapidScada platform : https://github.com/RapidScada/scada

Be careful with :
 - Need to add & install Nu packages like on the screen
   - opcfoundation.netstandard.opc.ua.1.3.352.10.nupkg
   - opcfoundation.netstandard.opc.ua.symbols.1.3.352.10.nupkg
   
   ![screen](https://image.noelshack.com/fichiers/2018/15/4/1523524870-2.png)
   
 - Check references needed in the project to know what you have to add by NuGet
 - Put your KpOpcUA.dll in KP folder
 - Need to move all DLLs from DLLs folder to ScadaComm folder.
 - Events of pre-compilation/post-compilation
 - - Need to move ScadaCommSvc.Config.xml in system32 folder for windows
   - Need to move ScadaCommMono.Config.xml in ScadaComm folder for linux
 - Need to move KpOpcUA_061.xml in ScadaComm/Config/ and change the IP OPC UA server (and ApplicationName in term of your OS)
 - Need to move Lang/KpOpcUA.en-GB.xml in ScadaComm/Lang/
 - Need to move OpcUADemo.tbl in Interface/DemoViews/
 - Need to modify database and pass them to ScadaServer (do it on the order of the screen)
   ![screen](https://image.noelshack.com/fichiers/2018/15/4/1523523661-1.png)
 - Always restart ScadaComm (& sometimes ScadaServer) to apply changes

Status :
 - Only Logic is working.
 - The form is not working, you must specify manually items in config files (KpOpcUA_061.xml & OpcUADemo.tbl) & in "Input Channels" in database.
   Ctrl+F "= null;//" to know the lines must be updated/adapted to this version of OPC UA DLLs (Core/Configuration/Client 1.3.352.10). Even if it's solved, the save/load configuration file is totally wrong with the actual organization.
 - Work with non-encrypted certificate. Must be tested with other type of certs

How is it working ?
![screen](https://image.noelshack.com/fichiers/2018/15/4/1523538814-sdkopcua.png)
