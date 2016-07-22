
Ultimate Goal: View the authorization code, access token, and id token that Google returns during an OpenId Connect request. 

This is the sample program that Microsoft ASP.NET Core team provides: 
https://github.com/aspnet/Security/tree/dev/samples/OpenIdConnectSample

This is the OpenID Connect Specification section that lists the Authorization Code Flow steps: 
http://openid.net/specs/openid-connect-core-1_0.html#CodeFlowSteps

# Fiddler Analysis

The Authorization Code Flow goes through the following steps.

# (1) Client prepares an Authentication Request containing the desired request parameters.
# (2) Client sends the request to the Authorization Server.

Step one and two happen thru a 302 redirection. First, the end-user requests login, then the client redirects us to Google.

## Request

```
GET http://localhost:5000/ HTTP/1.1
Host: localhost:5000
User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64; rv:47.0) Gecko/20100101 Firefox/47.0
Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8
Accept-Language: en-US,en;q=0.5
Accept-Encoding: gzip, deflate
Connection: keep-alive
```

## Response

```
HTTP/1.1 302 Found
Date: Fri, 22 Jul 2016 19:47:53 GMT
Content-Length: 0
Location: https://accounts.google.com/o/oauth2/v2/auth?client_id=384233509265-gv8949ukmpohkl092l84dbs2gpga7fa2.apps.googleusercontent.com&redirect_uri=http%3A%2F%2Flocalhost%3A5000%2Fsignin-oidc&response_type=code&scope=openid%20profile&response_mode=form_post&nonce=636048136738461505.ZThhMWU4NmItMjViZC00ZTBiLTk0OGEtOWE2NDZhMGExZWFhMTI5YzEwZjUtNjQ5NC00NmRmLTg4M2UtZWU3ZTdhZTIyZmMz&state=CfDJ8EflEPCuZdJHgUYffW9I8S9QcpFGIHbLBcEZ9qY7XA88hVtughcKQ7A0SUjY9zVPfdUw14r4_52B5qTwFW91eTkylhGGDQPfiJH_wIURfy8WhxEJ06XN7qh6kRtxqX8XcxkraWycktJC6srDsORDS1KbCj83j6gzhyVn-Nys6JlcMHqQjeUKS3T1Jt_eeSc5p7Uat4U7XaNivIQmdJgmp2V5apJVCePxxNrzZuv6uLBODBKdbRg0As7mor2P883FkH1f1U3jaZh22CTsM4jYNhftZSnh3CJALW8FZ2kZrBv38OFst4O1RxKtGZ5n0Gfr5NTBQscJ4s9LlDkkRN4sLVpPfmJyrmDaXF6e0Kbu-VKWVs83vrCTC2hQVHDS5XGb8g
Server: Kestrel
Set-Cookie: .AspNetCore.OpenIdConnect.Nonce.CfDJ8EflEPCuZdJHgUYffW9I8S8HaV8gYQQU3WHGQTe7MkgJ_0tClTzZlLXQj9HZ2PexTQz5QrNDkuDO9GIPJXrcLeUPEn1T3ZtjR7PUvft8PgutqzvnjnLPgT3fnZfOuX5IE5nhKeZQUlbusOr8n2d-7FTdQqaohS5SmxuC-Hz0w1DwzT_0wbYBNiHwMRUkOLD4ay5vF5GtkhXph3Pm-fQopBah4EEjWqTkY080jaaKaqtGN-yNS55sr6Bm_OKFfPpC9QjT6Qz6O7BtT45i22uQS2E=N; expires=Fri, 22 Jul 2016 20:02:53 GMT; path=/; httponly
Set-Cookie: .AspNetCore.Correlation.OpenIdConnect.7qk2gpy0FmiU5_dPhzR-253GfgSfmQXu-F4cTHx8RMQ=N; expires=Fri, 22 Jul 2016 20:02:53 GMT; path=/; httponly
```

# (3) Authorization Server Authenticates the End-User.
# (4) Authorization Server obtains End-User Consent/Authorization.

The is the request that comes out of the above 302 request. The response is Google's sign in page.

## Request

```
GET https://accounts.google.com/o/oauth2/v2/auth?client_id=384233509265-gv8949ukmpohkl092l84dbs2gpga7fa2.apps.googleusercontent.com&redirect_uri=http%3A%2F%2Flocalhost%3A5000%2Fsignin-oidc&response_type=code&scope=openid%20profile&response_mode=form_post&nonce=636048136738461505.ZThhMWU4NmItMjViZC00ZTBiLTk0OGEtOWE2NDZhMGExZWFhMTI5YzEwZjUtNjQ5NC00NmRmLTg4M2UtZWU3ZTdhZTIyZmMz&state=CfDJ8EflEPCuZdJHgUYffW9I8S9QcpFGIHbLBcEZ9qY7XA88hVtughcKQ7A0SUjY9zVPfdUw14r4_52B5qTwFW91eTkylhGGDQPfiJH_wIURfy8WhxEJ06XN7qh6kRtxqX8XcxkraWycktJC6srDsORDS1KbCj83j6gzhyVn-Nys6JlcMHqQjeUKS3T1Jt_eeSc5p7Uat4U7XaNivIQmdJgmp2V5apJVCePxxNrzZuv6uLBODBKdbRg0As7mor2P883FkH1f1U3jaZh22CTsM4jYNhftZSnh3CJALW8FZ2kZrBv38OFst4O1RxKtGZ5n0Gfr5NTBQscJ4s9LlDkkRN4sLVpPfmJyrmDaXF6e0Kbu-VKWVs83vrCTC2hQVHDS5XGb8g HTTP/1.1
Host: accounts.google.com
User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64; rv:47.0) Gecko/20100101 Firefox/47.0
Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8
Accept-Language: en-US,en;q=0.5
Accept-Encoding: gzip, deflate, br
Referer: http://localhost:5000/signout
Cookie: NID=82=b_nTwTiq9yav5BmNelgfLlcj_elv-TchNjXLyouF86Yskd3Fu1FAyQZrgVi0p4CubfVIEHpRiN64AQSaX5E7zcKSrJkqb-RPdgc7GV0PI-R_Chyx-j1EP4tsnEL5brKF43tMe7c81l4XMLHvzKdDAIt_lpbKeNDsNjVs_jpaZqz9GaNxFrV6g2hcSwbtJkOmxmK0MkQoyKxD9LVtedM4qPJ52mE5Uf4sVKDR5RlUeh1oAw0rWz70S_UmSu2GfQuT0Lr_TXC6M0nmYM3Mig9F0Q; GAPS=1:OIpw1Hlqb7eZN0hIJVjJED-vtvHIQg:pEMdi7UVvP6OJDpX; RMME=false; LSOLH=AH+1Ng3+8sZy7qhZr6QA2tkY3ld8VtDQ2iSrtPmCNcEL4wFpoTpbRT21anSI8jE1HIhlgHfBH1Npu1jaJnO21c2cmiW0LOoIHPP5xwEZoC+Pxvqu1932kyfYsqKKDqsH+kPMgCI+cBOa; OGPC=5061451-15:; GALX=XvL-JB-jlck; GMAIL_RTT=736; GoogleAccountsLocale_session=en; SID=jAMHIPNo3TzPd_Vyekc9tvjyXvclkC5Rbn99TtxnIIfy3plT5QTyz9773mhiXI3C_3VsPA.; LSID=s.CA|s.youtube:jAMHIHFxiPc9vJ2Z1rfz_VrJoGzXu_BcyUHHyk8B77-LrLPHIDx1wAxs8_ukCH-GuGHs5g.; HSID=AU0noBlt3JenL1e1C; SSID=A9Y3ru7ZdmsyWX_yg; APISID=qK8N1g_fPL5Z-o3j/Alc3fHZqCg6Zsv9oE; SAPISID=9zfO0rzqop_SLkdI/A9A7RzujQmVZ5_PR_
Connection: keep-alive
```

## Response

HTTP/1.1 200 OK
Content-Type: text/html; charset=utf-8
Cache-Control: no-cache, no-store, max-age=0, must-revalidate
Pragma: no-cache
Expires: Mon, 01 Jan 1990 00:00:00 GMT
Date: Fri, 22 Jul 2016 19:47:50 GMT
Content-Language: en
X-Content-Type-Options: nosniff
X-Frame-Options: SAMEORIGIN
X-XSS-Protection: 1; mode=block
Server: GSE
Alternate-Protocol: 443:quic
Alt-Svc: quic=":443"; ma=2592000; v="36,35,34,33,32,31,30,29,28,27,26,25"
Content-Length: 1611

<!DOCTYPE html><html><head><title>Forwarding ...</title><meta http-equiv="content-type" content="text/html; charset=utf-8"><meta http-equiv="X-UA-Compatible" content="IE=edge"><meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=0"><LINK href='https://ssl.gstatic.com/accounts/o/2213267783-approval_page_css_ltr.css' rel='stylesheet' type='text/css'>
  <style type="text/css">
    body {
      display: inline;
    }
  </style>
  </head><body  ><div id="button_div" class="modal-dialog-buttons"><form name="f" id="f" method="POST" action="http://localhost:5000/signin-oidc"><input type="hidden" name="state" value="CfDJ8EflEPCuZdJHgUYffW9I8S9QcpFGIHbLBcEZ9qY7XA88hVtughcKQ7A0SUjY9zVPfdUw14r4_52B5qTwFW91eTkylhGGDQPfiJH_wIURfy8WhxEJ06XN7qh6kRtxqX8XcxkraWycktJC6srDsORDS1KbCj83j6gzhyVn-Nys6JlcMHqQjeUKS3T1Jt_eeSc5p7Uat4U7XaNivIQmdJgmp2V5apJVCePxxNrzZuv6uLBODBKdbRg0As7mor2P883FkH1f1U3jaZh22CTsM4jYNhftZSnh3CJALW8FZ2kZrBv38OFst4O1RxKtGZ5n0Gfr5NTBQscJ4s9LlDkkRN4sLVpPfmJyrmDaXF6e0Kbu-VKWVs83vrCTC2hQVHDS5XGb8g" /><input type="hidden" name="code" value="4/KsMtdul10lD-QL-jOWqI9eD1MFN-l7BxdVWQ-WSE7GU" /><input type="hidden" name="authuser" value="0" /><input type="hidden" name="session_state" value="2d2c955740244bd6b984b51d68ffab7f5eb6ff9f..69f8" /><input type="hidden" name="prompt" value="none" /><noscript><button id="submit_approve_access" type="submit" tabindex="1" class="goog-buttonset-action" style="overflow:visible;">Continue</button></noscript></form></div><script type="text/javascript">document.forms['f'].submit();</script></body></html>

# (5) Authorization Server sends the End-User back to the Client with an Authorization Code.

This is Google's request back to the web client after the user has completed authentication and authorization. 

## Request

```
POST http://localhost:5000/signin-oidc HTTP/1.1
Host: localhost:5000
User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64; rv:47.0) Gecko/20100101 Firefox/47.0
Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8
Accept-Language: en-US,en;q=0.5
Accept-Encoding: gzip, deflate
Cookie: .AspNetCore.OpenIdConnect.Nonce.CfDJ8EflEPCuZdJHgUYffW9I8S8HaV8gYQQU3WHGQTe7MkgJ_0tClTzZlLXQj9HZ2PexTQz5QrNDkuDO9GIPJXrcLeUPEn1T3ZtjR7PUvft8PgutqzvnjnLPgT3fnZfOuX5IE5nhKeZQUlbusOr8n2d-7FTdQqaohS5SmxuC-Hz0w1DwzT_0wbYBNiHwMRUkOLD4ay5vF5GtkhXph3Pm-fQopBah4EEjWqTkY080jaaKaqtGN-yNS55sr6Bm_OKFfPpC9QjT6Qz6O7BtT45i22uQS2E=N; .AspNetCore.Correlation.OpenIdConnect.7qk2gpy0FmiU5_dPhzR-253GfgSfmQXu-F4cTHx8RMQ=N
Connection: keep-alive
Content-Type: application/x-www-form-urlencoded
Content-Length: 533

state=CfDJ8EflEPCuZdJHgUYffW9I8S9QcpFGIHbLBcEZ9qY7XA88hVtughcKQ7A0SUjY9zVPfdUw14r4_52B5qTwFW91eTkylhGGDQPfiJH_wIURfy8WhxEJ06XN7qh6kRtxqX8XcxkraWycktJC6srDsORDS1KbCj83j6gzhyVn-Nys6JlcMHqQjeUKS3T1Jt_eeSc5p7Uat4U7XaNivIQmdJgmp2V5apJVCePxxNrzZuv6uLBODBKdbRg0As7mor2P883FkH1f1U3jaZh22CTsM4jYNhftZSnh3CJALW8FZ2kZrBv38OFst4O1RxKtGZ5n0Gfr5NTBQscJ4s9LlDkkRN4sLVpPfmJyrmDaXF6e0Kbu-VKWVs83vrCTC2hQVHDS5XGb8g&code=4%2FKsMtdul10lD-QL-jOWqI9eD1MFN-l7BxdVWQ-WSE7GU&authuser=0&session_state=2d2c955740244bd6b984b51d68ffab7f5eb6ff9f..69f8&prompt=none
```

This is the parsed message body: 

* state=CfDJ8EflEPCuZdJHgUYffW9I8S9QcpFGIHbLBcEZ9qY7XA88hVtughcKQ7A0SUjY9zVPfdUw14r4_52B5qTwFW91eTkylhGGDQPfiJH_wIURfy8WhxEJ06XN7qh6kRtxqX8XcxkraWycktJC6srDsORDS1KbCj83j6gzhyVn-Nys6JlcMHqQjeUKS3T1Jt_eeSc5p7Uat4U7XaNivIQmdJgmp2V5apJVCePxxNrzZuv6uLBODBKdbRg0As7mor2P883FkH1f1U3jaZh22CTsM4jYNhftZSnh3CJALW8FZ2kZrBv38OFst4O1RxKtGZ5n0Gfr5NTBQscJ4s9LlDkkRN4sLVpPfmJyrmDaXF6e0Kbu-VKWVs83vrCTC2hQVHDS5XGb8g
* code=4%2FKsMtdul10lD-QL-jOWqI9eD1MFN-l7BxdVWQ-WSE7GU
* authuser=0
* session_state=2d2c955740244bd6b984b51d68ffab7f5eb6ff9f..69f8

prompt=none

## Response

```
HTTP/1.1 302 Found
Cache-Control: no-cache
Date: Fri, 22 Jul 2016 19:47:55 GMT
Pragma: no-cache
Content-Length: 0
Expires: -1
Location: http://localhost:5000/
Server: Kestrel
Set-Cookie: .AspNetCore.Correlation.OpenIdConnect.7qk2gpy0FmiU5_dPhzR-253GfgSfmQXu-F4cTHx8RMQ=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/
Set-Cookie: .AspNetCore.OpenIdConnect.Nonce.CfDJ8EflEPCuZdJHgUYffW9I8S8HaV8gYQQU3WHGQTe7MkgJ_0tClTzZlLXQj9HZ2PexTQz5QrNDkuDO9GIPJXrcLeUPEn1T3ZtjR7PUvft8PgutqzvnjnLPgT3fnZfOuX5IE5nhKeZQUlbusOr8n2d-7FTdQqaohS5SmxuC-Hz0w1DwzT_0wbYBNiHwMRUkOLD4ay5vF5GtkhXph3Pm-fQopBah4EEjWqTkY080jaaKaqtGN-yNS55sr6Bm_OKFfPpC9QjT6Qz6O7BtT45i22uQS2E=; expires=Thu, 01 Jan 1970 00:00:00 GMT; path=/
Set-Cookie: .AspNetCore.Cookies=CfDJ8EflEPCuZdJHgUYffW9I8S8sPzsQNIfCdq1N6aFjeECscgjk-QddjS7CaT7npqRQn6HYLt3gBwHn_xJVXKuqXNEAoI-li-kZZVH1PqcuX7Q-AwmbG16hN-lQTG7UXMnpqMY5nDnO5TDl8wlHYgPe9LvI-NZlExKp7iSiIp23cLbbsXdukc3QXg4X9l-nP9sq0vHdQfT2rZ-k9Jt_IrrsV14FYMmJbhQmBeJ--Fm8xcJQchGCuIMSNRatdXqiGIvYN-TQ_h8fTMOJ9Wueaon4r8LnrbNufxmdiVzS7Jbd71e63WoO4b0h9RHZLQCPUCprbPaJxEI-D2vcHwj709SV-DzZxHQhkl4WC2G7uVvOsbG8nhX6jNMWA5y94SFLFZPCTha_op6CMPY-6FBC7K3HjVCNSnqCNgs7G3ITWOvPj-20oTDIVnhNM94A2MF88eP0F0HRG9NsNv-3gP2ygkpwAM36Wh1l-hiCqRlKePVI1NB76Xww2_d-sTwBI-TSxlhQGQGo0eeRvr1Lkz92lSdv8DDYqgllfURdjeW-kkF1jm1yVu-J5EY5plCnoMb65FzRnXtEwJqBKBngxGy_j5US054qbVbSWmCdafc_cmzdjmaIpVrdroE9zu0fYTKKjZA_V51Chm_K4T9z7gFb914PXlvxoX9-el_6TjZPZSQY771p1eGjrXDtjym9G3Tdgt5plvLXbociKnW_0gcDm7pzhJOESrmlT1d1DsfR3eYHkg-6m2fEpxdsv5f7nYIBa92XXSc9BJ04pM4w6iS0sJNOkgnajn5ixxd4Lx11JR0DEzXIiWpIzsDPUE9fkC6OKMneENAwoMj-lE5Q_u_aNZTgUJqmfnV8zivwTcq61cDc-wME6koYwo2pJukUPZNE5SIJPHa-CmHWNtQ48yNdqpRXG_dXhgljuw7B-cYBOMneVNk1kJ5m7OhDU6pWi0eyn0_sWtN22249Q6b7cYNbjDxlFxduVNSgMT1BtBsfXwpdqZrKehKL5PlFRPYMnVq-UboEqg1kRaiSpmTvTdCyIrra8jomHjScpnySLYLecFomoC-xgKxhztuIVp35yjpYTfe-u8cOzRMIX68FcmYYF6WRXPkpRghtOARIuQiZTPL3XqhPkMF5WaQPDMAJFnjv_vAncIqe6Y6KwTrL7nozSSyFQC_4yH4aT9-FMhM3oYMwjXkVCR1UsgSwfpYSexn_wHRfOpGrHtJRb1WNNfTcpfB8MU9ukEO8b9SWsPHWx3rxQH4wJ2KyiqRT8xRKa08D7fU6JOAKeBeP7uKy_OuCHdX3mjQpE3nnstpaYB-ThF_z5H3EnA1qml7ocOKZUAe9GvD1dKI72xmEl53ePXyGDQVORgnaiJqSV7oXDumNM4r7qTWr9SUK5W5UvCTuO_RUr4H4AkDhUHd-eN5AmqyojMsR2k478MkOP_8gwwZp30uYA2_ipPJmERgQcf7MCuhOKhtrXTU4b1BKRVRbtf4XqrERFpyeO0EdsnJayto4wA2gzuqy-SJXUyy0EDoCvCg7ZPUMEZVdzVPOernSB-BIyWXgl1RVybm484w_5mTLRi2_UiDRy2OPvqj7rrnBY7HfDY2FLqlWSVK-KgHNPygWkCZt7oIB-638MoFaGzBTH8FpK-EXiREYTDgjLiujSiA8VAirMmmG7-XEsQak3CX95NM3NPAs3zn4cvWSnxC-EP5gX-NNRglPPY-LSGi8ctHzir_2zfULCub0021374Di1aM_GvlJ1fF6lZBOW9Lah8v8wa7jATzri0xAL3ZpYYWdgkpMMDbllaDCaeEKtNITW269-yncn4Z3HBps4dmpz0lxH22QFvcmHLiyWJxmWMh7jWYcHQAZc5zUmIyJy8lf_dNgDi8wsktlFCWqt9WbetXhgvyuvwjB6pXUT4C2GtJDmNKx-0kwEFxesa1vRL8o6LIb9Swy2ZHh4kxIkDmL-R2d2ckOn_V8WEyF7YxVf3RZJHT2qjO3mo_qsFcjs_uXnix3B5x8vGpXsAA-RYG09UnfUzow6MlGe8kD6QAQPClbBB0mCl-8kpyWTVNHoqjdMNZSNI2n-lGRwASmET8P39Jf1b4IsQvuJ_HCNOxozndEd9Yewj7aTclbBgFLEGWA8usAiARpqwP-LgSP-NZpWtjKxwYgVcgqneJQk8vS60DjnBiSXnferptiWaEDEgmBAQnzNAGVUUHI5Ez9qrnTRKQEPeULZBuijitEy2cQCsoOCTL8owUxNHB8ZwFYpI-hlsS5hVJlJoSYbidqTBqaCLlgGQucVGKyAOoHdJbTBEx2h3TJGubuNqSdPp0ZYtvKkPKN7ctM74AFLQejkKJ5ipidVu7oFjY36MIsWF6vef-b9Rypk98iiUCzEyl48fHHxTpmqvRBy18LtiPOBf40KVW3-nvB0X6wDsOkXXK7jcko_0wvtsJfmtEj0ZWDCta1qQx5uffnY9I4JoE22MiK6T0NiZ64VGg7ZLrjGGl--wff5iVtF_Mm212dnHtlWHF1PT_XuQDJKxQrg12s_I0mlxqD1fpbYCVWvWc8LTceBazIR-UgJz3pjqARl69wzWMNmGgmkX7AINC4XAV9dxG6U2-B6xrHYnsq_1QiALdjRrp2kS9W1zJXJkd6EZxvzdAABk1zYnZWAG8FITq0MzinQph-KGOuJW7FaiDSHtlOFp7y6om8DjEbXXUHX-aB5dUSs9yvb3GZiDO26IwIKRuUJXdJA1aQ_XgNsalTSwSM0ICnr6cgz8eSQOHo8KTywS_yBVfDj8qXYa9WVfF_HwAnYbm4JxuTSzFFJJzQX4gVdHU9zc1DasVxVTQfnXOaQQUV6eOoNEM9XjRN3aK-VcQHH1nRaVrCd4tcozbpAWSNzUAiUF9VpIt_fJ1-2vj415gGOp47Eq-GJyYBogzjLM2P1I6NvmV7uFoHaq0s0IhrTa6awIap8EUYxJDYahcj7VpGoKuCXuAQVuhnpsKQmWAyTY6pssqHvvEjesXo6Xm6SOw0RmC64zpAjKVmrHHRH827Zfgo-gNHe2HxvID6ibVZ8VJDgOoAS6xCInZVwAqs2yfjDO7nTtr27m3hgG82klsVNrJkocFQjk5szDMlWqTJOD0ZIWxnxGocEUj-KmqzXtGllPpw-BFIzB4E8un6w6q5nRzLgtAyOTtjxHPf-aeaN-076_xKsQI2QS3HAUJMd6XInawDLilLk8FoMq-hgBymdF6v5IK6j_GQs6hxFKfe0eLNpOc6CwSWjbRJGZhDa73uGnEBCbH3ZRj_8NAd7AOk0M-peY-j8anESv1QJfLArBQZMS2vs1bo5bD-bsBXZmWsZwca2TBxCaDaL1tjy63HF7VfgP4; path=/; httponly
```

# (6) Client requests a response using the Authorization Code at the Token Endpoint.
# (7) Client receives a response that contains an ID Token and Access Token in the response body.

## Request

```
POST https://www.googleapis.com/oauth2/v4/token HTTP/1.1
Connection: Keep-Alive
Content-Type: application/x-www-form-urlencoded
Accept-Encoding: gzip, deflate
User-Agent: Microsoft ASP.NET Core OpenIdConnect middleware
Content-Length: 261
Host: www.googleapis.com

client_id=384233509265-gv8949ukmpohkl092l84dbs2gpga7fa2.apps.googleusercontent.com&client_secret=9y0_fis1pxuDVeJJ3CtK7VbU&code=4%2FKsMtdul10lD-QL-jOWqI9eD1MFN-l7BxdVWQ-WSE7GU&grant_type=authorization_code&redirect_uri=http%3A%2F%2Flocalhost%3A5000%2Fsignin-oidc
```

* client_id=384233509265-gv8949ukmpohkl092l84dbs2gpga7fa2.apps.googleusercontent.com
* client_secret=9y0_fis1pxuDVeJJ3CtK7VbU
* code=4%2FKsMtdul10lD-QL-jOWqI9eD1MFN-l7BxdVWQ-WSE7GU
* grant_type=authorization_code
* redirect_uri=http%3A%2F%2Flocalhost%3A5000%2Fsignin-oidc

## Response

```
HTTP/1.1 200 OK
Cache-Control: no-cache, no-store, max-age=0, must-revalidate
Pragma: no-cache
Expires: Mon, 01 Jan 1990 00:00:00 GMT
Date: Fri, 22 Jul 2016 19:47:52 GMT
Vary: Origin
Vary: X-Origin
Content-Type: application/json; charset=UTF-8
X-Content-Type-Options: nosniff
X-Frame-Options: SAMEORIGIN
X-XSS-Protection: 1; mode=block
Server: GSE
Alternate-Protocol: 443:quic
Alt-Svc: quic=":443"; ma=2592000; v="36,35,34,33,32,31,30,29,28,27,26,25"
Content-Length: 1517

{
 "access_token": "ya29.CjQoA2z_7FMTHZ2KOip5PIG2iVaAbU8RyzRASRV1mrIv8bjt-t10EIb4vWxDY2yudbS-UeVv",
 "token_type": "Bearer",
 "expires_in": 3598,
 "id_token": "eyJhbGciOiJSUzI1NiIsImtpZCI6ImQ5Zjg0M2ZmNTVkMDg4OGYzNDc5NDAyZjk2ZGZiNzc0YzJiNjczYzgifQ.eyJpc3MiOiJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20iLCJhdF9oYXNoIjoic3BUR1Z6NU5VdFlTb1ZuUUJTYlQ3USIsInN1YiI6IjEwNDI0NDg3OTQ0NDU5MDIzMDE4MSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJub25jZSI6IjYzNjA0ODEzNjczODQ2MTUwNS5aVGhoTVdVNE5tSXRNalZpWkMwMFpUQmlMVGswT0dFdE9XRTJORFpoTUdFeFpXRmhNVEk1WXpFd1pqVXROalE1TkMwME5tUm1MVGc0TTJVdFpXVTNaVGRoWlRJeVptTXoiLCJhdWQiOiIzODQyMzM1MDkyNjUtZ3Y4OTQ5dWttcG9oa2wwOTJsODRkYnMyZ3BnYTdmYTIuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJhenAiOiIzODQyMzM1MDkyNjUtZ3Y4OTQ5dWttcG9oa2wwOTJsODRkYnMyZ3BnYTdmYTIuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJoZCI6InNoYXVubHV0dGluLmNvbSIsImVtYWlsIjoiYWRtaW5Ac2hhdW5sdXR0aW4uY29tIiwiaWF0IjoxNDY5MjE2ODcyLCJleHAiOjE0NjkyMjA0NzIsIm5hbWUiOiJTaGF1biBMdXR0aW4iLCJwaWN0dXJlIjoiaHR0cHM6Ly9saDMuZ29vZ2xldXNlcmNvbnRlbnQuY29tLy1RUE5VZDhmcFp0NC9BQUFBQUFBQUFBSS9BQUFBQUFBQUFndy9GcGROclNyWXZKTS9zOTYtYy9waG90by5qcGciLCJnaXZlbl9uYW1lIjoiU2hhdW4iLCJmYW1pbHlfbmFtZSI6Ikx1dHRpbiIsImxvY2FsZSI6ImVuIn0.gJclxvapMVJePvzRiC3TzqltQ-ZaLQroVNxCrAJPvLMiJ9J_gscIdUXxffWtoRlWYx660vtSw31J8i_zj2X6lDt6XPwJQsqvgjP593klC_ueuOR8N01fi3Gi68Vom9BZcUKI65RzF4fN2a5_THv9N-uEkxITsRU36CHLJ0Ek4WfRlXMXH5GXS7AbF5zh-yPBXdHrqHLnzg4x5sF67uayt8kvDYLt4oCBv-5Pl2TbO6JYx1r_c8GNaRNj7f2TLQ5o-QkYD-EH2glZdOdkg1S_PPsVHcHDS8ower_606zWu8gGjJw-KJTIA-HP9-PZI8VDvu95yWLMSFd7DIefY0QStQ"
}
```

# (8) Client validates the ID token and retrieves the End-User's Subject Identifier.

Both the access_token and the id_token as JSON Web Tokens. We can parse them.

