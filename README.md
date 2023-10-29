# LEDSegmentDisplayRemote
一个通过Windows无线局域网控制树莓派PicoW显示4位小数点数码管的东西

## 4位数码管引脚图(12针脚)  
![Image text](https://github.com/LunaroakF/LEDSegmentDisplayRemote/blob/master/pic1.png)  

## 树莓派picow接线图
![Image text](https://github.com/LunaroakF/LEDSegmentDisplayRemote/blob/master/RaspberryPi_Pico_W/pic.png)  
![Image text](https://github.com/LunaroakF/LEDSegmentDisplayRemote/blob/master/pic2.jpg)  

请参考RaspberryPi_Pico_W文件夹下的main.py  
```Python
c_a=16
c_b=28
c_c=9
c_d=14
c_e=15
c_f=26
c_g=10
c_dp=13
c_com1=17
c_com2=22
c_com3=21
c_com4=6
```
|数码管对应灯段|a|b|c|d|e|f|g|dp|com1|com2|com3|com4|
|--|--|--|--|--|--|--|--|--|--|--|--|--|
|树莓派PicoW对应GPIO|16|28|9|14|15|26|10|13|17|22|21|6|

## 设置PicoW网络连接  
请参考RaspberryPi_Pico_W文件夹下的main.py  
有点麻烦的是要在前面的IP变量改成到时候会连接的WIFI给的IP(预测一下下，我也不知道咋搞emmm)
```Python
WIFIConnect.ConnectWIFI('LunaroakF','12345678')
```
调用main.py目录下WIFIConnect.py中的ConnectWIFI方法连接Wifi 后面是Wifi的SSID与密码
连接成功后树莓派PicoW的IP可在自己路由器里查找或者查看PicoW的输出

## 系统时间成果图
![Image text](https://github.com/LunaroakF/LEDSegmentDisplayRemote/blob/master/pic3.jpg)  

