
# Steps

Install WireShark. 

Install Npcap.

Run the following in PowerShell. 

    [System.Environment]::SetEnvironmentVariable("SSLKEYLOGFILE", "C:\Wireshark\sslkeylog.log", [System.EnvironmentVariableTarget]::Machine);

Restart Windows. 

Start Wireshark.

* Edit > Preferences > Protocols > SSL > (Pre)-Master-Secret log filename: "C:\Wireshark\sslkeylog.log"
* Capture > Options > Input > npcap Loopback Adapter, Wi-Fi.

Set the display filter to `ssl or (http and tcp) and ip.dst == your_ip`. 

    * We filter on ip.dst == your_ip because we can only decrypt content sent to our computer.

# See also 

https://jimshaver.net/2015/02/11/decrypting-tls-browser-traffic-with-wireshark-the-easy-way/
http://security.stackexchange.com/questions/35639/decrypting-tls-in-wireshark-when-using-dhe-rsa-ciphersuites/42350#42350