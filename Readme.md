Powershell Impersonation Module
===============================

Start-Impersonation
-------------------

Impersonates an authenticated user until Stop-Impersonation is called.

Parameters:

* Username - The username of the account to be impersonated.

* Password - The password of the account to be impersonated.

Returns:

* Account object

Stop-Impersonation
------------------

Sets the current user account back to the logged on user.

Parameters:

* Account - The account object returned by Start-Impersonation.

Usage
-----
```
$Acct = Start-Impersonation Username Password

  Run code as impersonated user

Stop-Impersonation $Acct
```