import machine
from machine import Pin
import sys
import _thread
import socket
import time
import WIFIConnect

IP="192.168.0.121"  #设备的内网IP
Port=2000  #监听的端口

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

LED = Pin("LED", Pin.OUT)#板载LED  

a = Pin(c_a, Pin.OUT)
b = Pin(c_b, Pin.OUT)
c = Pin(c_c, Pin.OUT)
d = Pin(c_d, Pin.OUT)
e = Pin(c_e, Pin.OUT)
f = Pin(c_f, Pin.OUT)
g = Pin(c_g, Pin.OUT)
dp = Pin(c_dp, Pin.OUT)
com1 = Pin(c_com1, Pin.OUT)
com2 = Pin(c_com2, Pin.OUT)
com3 = Pin(c_com3, Pin.OUT)
com4 = Pin(c_com4, Pin.OUT)

LED.value(1)
#print("链接WIFI...")
WIFIConnect.ConnectWIFI('LunaroakF','19645277')
LED.value(0)

N1=0
N2=0
N3=0
N4=0
D1=False
D2=False
D3=False
D4=False


def offall():
    a.value(0)
    b.value(0)
    c.value(0)
    d.value(0)
    e.value(0)
    f.value(0)
    g.value(0)
    dp.value(0)
    com1.value(1)
    com2.value(1)
    com3.value(1)
    com4.value(1)

def upall():
    a.value(1)
    b.value(1)
    c.value(1)
    d.value(1)
    e.value(1)
    f.value(1)
    g.value(1)
    dp.value(1)
    com1.value(0)
    com2.value(0)
    com3.value(0)
    com4.value(0)

###########################################
def ToNum0(dot):
    a.value(1)
    b.value(1)
    c.value(1)
    d.value(1)
    e.value(1)
    f.value(1)
    if dot:
        dp.value(1)
        
def ToNum1(dot):
    b.value(1)
    c.value(1)
    if dot:
        dp.value(1)
        
def ToNum2(dot):
    a.value(1)
    b.value(1)
    d.value(1)
    e.value(1)
    g.value(1)
    if dot:
        dp.value(1)
        
def ToNum3(dot):
    a.value(1)
    b.value(1)
    c.value(1)
    d.value(1)
    g.value(1)
    if dot:
        dp.value(1)
        
def ToNum4(dot):
    b.value(1)
    c.value(1)
    g.value(1)
    f.value(1)
    if dot:
        dp.value(1)
        
def ToNum5(dot):
    a.value(1)
    c.value(1)
    d.value(1)
    g.value(1)
    f.value(1)
    if dot:
        dp.value(1)
        
def ToNum6(dot):
    a.value(1)
    c.value(1)
    d.value(1)
    e.value(1)
    f.value(1)
    g.value(1)
    if dot:
        dp.value(1)
        
def ToNum7(dot):
    a.value(1)
    b.value(1)
    c.value(1)
    if dot:
        dp.value(1)
        
def ToNum8(dot):
    a.value(1)
    b.value(1)
    c.value(1)
    d.value(1)
    e.value(1)
    f.value(1)
    g.value(1)
    if dot:
        dp.value(1)
        
def ToNum9(dot):
    a.value(1)
    b.value(1)
    c.value(1)
    d.value(1)
    f.value(1)
    g.value(1)
    if dot:
        dp.value(1)
        
def ToNumB(dot):
    a.value(0)
    b.value(0)
    c.value(0)
    d.value(0)
    e.value(0)
    f.value(0)
    g.value(0)
    dp.value(0)
    if dot:
        dp.value(1)
        
def ToErr1():
    a.value(1)
    e.value(1)
    d.value(1)
    f.value(1)
    g.value(1)
    
def ToErr2():
    e.value(1)
    g.value(1)
    
def ToErr3():
    e.value(1)
    g.value(1)
    
def ToErr4():
    a.value(1)
    b.value(1)
    c.value(1)
    d.value(1)
    e.value(1)
    f.value(1)
    dp.value(1)
    
def ToErrF(dot):
    g.value(1)
    if dot:
        dp.value(1)
    
###########################################
def JugeNumber(number,dot):
    offall()
    if number==0:
        ToNum0(dot)
    elif number==1:
        ToNum1(dot)
    elif number==2:
        ToNum2(dot)
    elif number==3:
        ToNum3(dot)
    elif number==4:
        ToNum4(dot)
    elif number==5:
        ToNum5(dot)
    elif number==6:
        ToNum6(dot)
    elif number==7:
        ToNum7(dot)
    elif number==8:
        ToNum8(dot)
    elif number==9:
        ToNum9(dot)
    elif number==10:
        ToNumB(dot)
    elif number==11:
        ToErrF(dot)
    elif number==6666:
        ToErr1()
    elif number==7777:
        ToErr2()
    elif number==8888:
        ToErr3()
    elif number==9999:
        ToErr4()
    

def DisplayCom1(number,dot):
    JugeNumber(number,dot)       
    com1.value(0)
    com2.value(1)
    com3.value(1)
    com4.value(1)
    
def DisplayCom2(number,dot):
    JugeNumber(number,dot)
    com1.value(1)
    com2.value(0)
    com3.value(1)
    com4.value(1)
    
def DisplayCom3(number,dot):
    JugeNumber(number,dot)   
    com1.value(1)
    com2.value(1)
    com3.value(0)
    com4.value(1)
    
def DisplayCom4(number,dot):
    JugeNumber(number,dot)
    com1.value(1)
    com2.value(1)
    com3.value(1)
    com4.value(0)

offall()

def Fresh():
    global Number
    global N1
    global N2
    global N3
    global N4
    global D1
    global D2
    global D3
    global D4
    waittime=0.002
    while True:
        DisplayCom1(N1,D1)
        time.sleep(waittime)
        DisplayCom2(N2,D2)
        time.sleep(waittime)
        DisplayCom3(N3,D3)
        time.sleep(waittime)
        DisplayCom4(N4,D4)
        time.sleep(waittime)
        #if controlbutton.value() == 0:
            #time.sleep_ms(20)
            #if controlbutton.value() == 0:
                #DisplayCom4(0,True)
                #print("thread exit.")
                #_thread.exit()

def Wificl():
    global N1
    global N2
    global N3
    global N4
    global D1
    global D2
    global D3
    global D4
    global IP
    global Port
    while True:
        try:
            server=socket.socket()
            server.bind((IP,Port))
            server.listen() #监听
            #print("监听已开始")
            conne,addr=server.accept()
            #print(conn,addr)
            #print("用户已连接")
            while True:
                try:
                    data=conne.recv(15)
                    maindata=str(data)
                    datalist=maindata.split("'")
                    maindata=datalist[1]
                    #print("用户数据:"+maindata)
                    group=maindata.split("-")
                    
                    #填充空白
                    if(group[0]!="B" and group[0]!="F"):
                        N1=int(group[0])
                    else:
                        N1=10
                        
                    if(group[1]!="B" and group[1]!="F"):
                        N2=int(group[1])
                    else:
                        N2=10
                        
                    if(group[2]!="B" and group[2]!="F"):
                        N3=int(group[2])
                    else:
                        N3=10
                    
                    if(group[3]!="B" and group[3]!="F"):
                        N4=int(group[3])
                    else:
                        N4=10
                    #负号
                    if(group[0]=="F"):
                        N1=11  
                    if(group[1]=="F"):
                        N2=11
                    if(group[2]=="F"):
                        N3=11
                    if(group[3]=="F"):
                        N4=11
                    #小数点
                    if group[4]=="1":
                        D1=True
                    else:
                        D1=False
                        
                    if group[5]=="1":
                        D2=True
                    else:
                        D2=False
                        
                    if group[6]=="1":
                        D3=True
                    else:
                        D3=False
                        
                    if group[7]=="1":
                        D4=True
                    else:
                        D4=False
                    #ProcessData(maindata)
                    #conne.close()
                except:
                    print("error1")
                    N1=6666
                    N2=7777
                    N3=8888
                    N4=9999
                    conne.close()
                    break
        except:
            #print("error1")
            conne.close()
            N1=6666
            N2=7777
            N3=8888
            N4=9999
            


_thread.start_new_thread(Fresh,())
Wificl()
