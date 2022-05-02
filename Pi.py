import RPi.GPIO as GPIO
import threading
import socket
import time


GPIO.setwarnings(False) 
GPIO.setmode(GPIO.BOARD)

N1=8
N2=8
N3=8
N4=8
D1=False
D2=True
D3=False
D4=False

a=12
b=40
c=15
d=11
e=29
f=16
g=37
dp=13
com1=32
com2=36
com3=38
com4=7

GPIO.setup(a, GPIO.OUT)
GPIO.setup(b, GPIO.OUT)
GPIO.setup(c, GPIO.OUT)
GPIO.setup(d, GPIO.OUT)
GPIO.setup(e, GPIO.OUT)
GPIO.setup(f, GPIO.OUT)
GPIO.setup(g, GPIO.OUT)
GPIO.setup(dp, GPIO.OUT)

GPIO.setup(com1, GPIO.OUT)
GPIO.setup(com2, GPIO.OUT)
GPIO.setup(com3, GPIO.OUT)
GPIO.setup(com4, GPIO.OUT)

def offall():
    GPIO.output(com1, GPIO.HIGH)
    GPIO.output(com2, GPIO.HIGH)
    GPIO.output(com3, GPIO.HIGH)
    GPIO.output(com4, GPIO.HIGH)
    GPIO.output(a, GPIO.LOW)
    GPIO.output(b, GPIO.LOW)
    GPIO.output(c, GPIO.LOW)
    GPIO.output(d, GPIO.LOW)
    GPIO.output(e, GPIO.LOW)
    GPIO.output(f, GPIO.LOW)
    GPIO.output(g, GPIO.LOW)
    GPIO.output(dp, GPIO.LOW)

def upall():
    GPIO.output(a, GPIO.HIGH)#a
    GPIO.output(b, GPIO.HIGH)#b
    GPIO.output(c, GPIO.HIGH)#c
    GPIO.output(d, GPIO.HIGH)#d
    GPIO.output(e, GPIO.HIGH)#e
    GPIO.output(f, GPIO.HIGH)#f
    GPIO.output(g, GPIO.HIGH)#g
    GPIO.output(dp, GPIO.HIGH)#dp
    GPIO.output(com1, GPIO.LOW)#千位
    GPIO.output(com2, GPIO.LOW)#百位
    GPIO.output(com3, GPIO.LOW)#十位
    GPIO.output(com4, GPIO.LOW)#个位
    
    
###########################################
def ToNum0(dot):
    GPIO.output(a, GPIO.HIGH)
    GPIO.output(b, GPIO.HIGH)
    GPIO.output(c, GPIO.HIGH)
    GPIO.output(d, GPIO.HIGH)
    GPIO.output(e, GPIO.HIGH)
    GPIO.output(f, GPIO.HIGH)
    if dot:
        GPIO.output(dp, GPIO.HIGH)
def ToNum1(dot):
    GPIO.output(b, GPIO.HIGH)
    GPIO.output(c, GPIO.HIGH)
    if dot:
        GPIO.output(dp, GPIO.HIGH)
def ToNum2(dot):
    GPIO.output(a, GPIO.HIGH)
    GPIO.output(b, GPIO.HIGH)
    GPIO.output(d, GPIO.HIGH)
    GPIO.output(e, GPIO.HIGH)
    GPIO.output(g, GPIO.HIGH)
    if dot:
        GPIO.output(dp, GPIO.HIGH)
def ToNum3(dot):
    GPIO.output(a, GPIO.HIGH)
    GPIO.output(b, GPIO.HIGH)
    GPIO.output(c, GPIO.HIGH)
    GPIO.output(d, GPIO.HIGH)
    GPIO.output(g, GPIO.HIGH)
    if dot:
        GPIO.output(dp, GPIO.HIGH)
def ToNum4(dot):
    GPIO.output(b, GPIO.HIGH)
    GPIO.output(c, GPIO.HIGH)
    GPIO.output(g, GPIO.HIGH)
    GPIO.output(f, GPIO.HIGH)
    if dot:
        GPIO.output(dp, GPIO.HIGH)
def ToNum5(dot):
    GPIO.output(a, GPIO.HIGH)
    GPIO.output(c, GPIO.HIGH)
    GPIO.output(d, GPIO.HIGH)
    GPIO.output(g, GPIO.HIGH)
    GPIO.output(f, GPIO.HIGH)
    if dot:
        GPIO.output(dp, GPIO.HIGH)
def ToNum6(dot):
    GPIO.output(a, GPIO.HIGH)
    GPIO.output(c, GPIO.HIGH)
    GPIO.output(d, GPIO.HIGH)
    GPIO.output(e, GPIO.HIGH)
    GPIO.output(f, GPIO.HIGH)
    GPIO.output(g, GPIO.HIGH)
    if dot:
        GPIO.output(dp, GPIO.HIGH)
def ToNum7(dot):
    GPIO.output(a, GPIO.HIGH)
    GPIO.output(b, GPIO.HIGH)
    GPIO.output(c, GPIO.HIGH)
    if dot:
        GPIO.output(dp, GPIO.HIGH)
def ToNum8(dot):
    GPIO.output(a, GPIO.HIGH)
    GPIO.output(b, GPIO.HIGH)
    GPIO.output(c, GPIO.HIGH)
    GPIO.output(d, GPIO.HIGH)
    GPIO.output(e, GPIO.HIGH)
    GPIO.output(f, GPIO.HIGH)
    GPIO.output(g, GPIO.HIGH)
    if dot:
        GPIO.output(dp, GPIO.HIGH)
def ToNum9(dot):
    GPIO.output(a, GPIO.HIGH)
    GPIO.output(b, GPIO.HIGH)
    GPIO.output(c, GPIO.HIGH)
    GPIO.output(d, GPIO.HIGH)
    GPIO.output(f, GPIO.HIGH)
    GPIO.output(g, GPIO.HIGH)
    if dot:
        GPIO.output(dp, GPIO.HIGH)
###########################################
def JugeNumber(number,dot):
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
               
def DisplayCom1(number,dot):
    offall()
    #GPIO.output(d, GPIO.HIGH)
    #GPIO.output(e, GPIO.HIGH)
    #GPIO.output(f, GPIO.HIGH)
    JugeNumber(number,dot)       
    GPIO.output(com1, GPIO.LOW)
    
def DisplayCom2(number,dot):
    offall()
    #GPIO.output(e, GPIO.HIGH)
    #GPIO.output(f, GPIO.HIGH)
    JugeNumber(number,dot)
    GPIO.output(com2, GPIO.LOW)
    
def DisplayCom3(number,dot):
    offall()
    #GPIO.output(b, GPIO.HIGH)
    #GPIO.output(c, GPIO.HIGH)
    #GPIO.output(e, GPIO.HIGH)
    #GPIO.output(f, GPIO.HIGH)
    #GPIO.output(g, GPIO.HIGH)
    JugeNumber(number,dot)   
    GPIO.output(com3, GPIO.LOW)
    
def DisplayCom4(number,dot):
    offall()
    #GPIO.output(b, GPIO.HIGH)
    #GPIO.output(c, GPIO.HIGH)
    #GPIO.output(e, GPIO.HIGH)
    #GPIO.output(f, GPIO.HIGH)
    #GPIO.output(d, GPIO.HIGH)
    JugeNumber(number,dot)
    GPIO.output(com4, GPIO.LOW)
    

offall()

def Fresh():
    waittime=0.00002
    while True:
        DisplayCom1(N1,D1)
        time.sleep(waittime)
        
        #DisplayCom2(N2,D2)
        #time.sleep(waittime)
        #DisplayCom3(N3,D3)
        #time.sleep(waittime)
        #DisplayCom4(N4,D4)
        #time.sleep(waittime)
        
def UpdateTime():
    global N1
    global N2
    global N3
    global N4
    waittime=0.01
    while True:
        Hour=time.strftime('%H',time.localtime(time.time()))
        Minu=time.strftime('%M',time.localtime(time.time()))
        H=list(Hour)
        M=list(Minu)
        #N1=int(H[0])
        N2=int(H[1])
        N3=int(M[0])
        N4=int(M[1])
        time.sleep(waittime)

def UpdateDot():
    global D2
    while True:
        if D2==False:
            D2=True
        else:
            D2=False
        time.sleep(0.5)

        
        
def Wificl():
    global N1
    global N2
    global N3
    global N4
    while True:
        try:
            server=socket.socket()
            server.bind(("192.168.0.114",23333)) 
            server.listen() #监听
            print("监听已开始")
            conn,addr=server.accept() #等电话来,conn就是客户端连接过来，而在服务器端为其生成的一个链接实例
            print(conn,addr)
            print("用户已连接")
            while True:
                try:
                    data=conn.recv(1024)
                    maindata=str(data)
                    maindata=maindata.split("'")[1]
                    N1=int(maindata)
                    print(maindata)
                    #conn.send(data.upper())
                except:
                    print("error1")
                    conn.close()
                    break
        except:
            print("error2")

        
        
        

t_Fresh = threading.Thread(target=Fresh)
t_UpdateTime = threading.Thread(target=UpdateTime)
t_UpdateDot = threading.Thread(target=UpdateDot)
t_Wificl = threading.Thread(target=Wificl)
t_Fresh.start()
t_UpdateTime.start()
t_UpdateDot.start()
t_Wificl.start()




