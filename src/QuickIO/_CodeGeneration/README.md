This project is for code generation only. You cannot use T4 scripts in a Shared Project right now.
https://visualstudio.uservoice.com/forums/121579-visual-studio-2015/suggestions/6720163-allow-usiing-t4-template-in-shared-project

FAQ:
================
Error: [...]must be either local to this computer or part of your trusted zone.
       If you have downloaded this template, you may need to 'Unblock' it using the properties page for the template file in Windows Explorer.

Solution: 
- Download http://technet.microsoft.com/en-us/sysinternals/bb897440.aspx and extract to Windows\System32 Folder
- Run @ cmd: streams -s -d C:\path\to\QuickIO.CodeGeneration
================