from makinetasarim import Ui_MainWindow
# from PyQt5.QtCore import *
from PyQt5.QtCore import QObject, pyqtSignal
from PyQt5.QtGui import *
from PyQt5 import QtWidgets
from PyQt5.QtWidgets import *
import threading
import sys
import numpy as np
import pandas as pd
#sinir ağı classı
epok=2
satir=0
class Sinir_Agi(QObject):
    tbstring=""
    trigger = pyqtSignal()
    yayma=pyqtSignal()
    # def __init__(self):
    #  Sinir ağı #değişkenler
    ilkadimbias=np.array(([-0.24,-2.4]),dtype=float)
    ikincibias=np.array(([-2.12]),dtype=float)
    #başlangıç ağırlıkları
    A1=np.array(([-2.11,1.83,1.49],[0.69,1.12,1.97]),dtype=float)
    A2=np.array(([-2.89],[-1.36]),dtype=float) 
    a=[]
    # Sinir ağı fonksiyonları
    #geri yayılım ve öğretme fonksiyonu
    def ögretici(self, giris,cikis):
        Ileri=self.ileri(giris)
        self.geri(giris,cikis,Ileri)
    #geri yayılım
    def geri(self,giris,cikis,Ileri):
        delta3=Ileri*(1-Ileri)*(cikis[0]-Ileri)
        self.ikincibias=self.ikincibias+(1*delta3*1)
        self.A2[0]=self.A2[0]+(1*delta3*self.sigmoidcarp1[0])
        self.A2[1]=self.A2[1]+(1*delta3*self.sigmoidcarp1[1])
        delta1=self.sigmoidcarp1[0]*(1-self.sigmoidcarp1[0])*self.A2[0]*delta3
        delta2=self.sigmoidcarp1[1]*(1-self.sigmoidcarp1[1])*self.A2[1]*delta3
        self.ilkadimbias[0]=self.ilkadimbias[0]+(1*delta1*1)
        self.ilkadimbias[1]=self.ilkadimbias[1]+(1*delta2*1)
        for i in range(len(giris)):
            self.A1[0][i]=self.A1[0][i]+(1*delta1*giris[i])
            self.A1[1][i]=self.A1[1][i]+(1*delta2*giris[i])
    #sigmoid fonksiyonu
    def sigmoid(self, s):
        return 1/(1+np.exp(-1*s))
    #ileri yayılım-topolojide ilerleme
    def ileri(self,giris):
        carp1=np.dot(self.A1,giris)
        biaslicarp1=np.sum([carp1,self.ilkadimbias],axis=0)
        self.sigmoidcarp1=self.sigmoid(biaslicarp1)
        carp2=np.dot(self.sigmoidcarp1,self.A2)
        biaslicarp2=np.sum([carp2,self.ikincibias],axis=0)
        sigmoidcarp2=self.sigmoid(biaslicarp2)
        return sigmoidcarp2                 
    def test(self):
        self.tbstring=self.tbstring+"*************************************** \n Test Sonucu Çıkışlar:{}".format(self.ileri(giris[satir]))+"\n **************************************\n"
        return self.tbstring
    def degiskenler(self):
        self.tbstring="Eğitimimiz "+str(epok)+" epok sürmüştür\n"+str(satir+1)+".satir eğitime dahil edilmemiş ve test yapılmıştır \n"+"Giriş {} ve Çıkış {} Değerleri".format(giris[satir],cikis[satir])+"\n"
        self.tbstring=self.tbstring+"Eğitim Sonucu Son Ağırlıklar ve Bias Değerleri \n1.giden ağırlıklar:"+str(self.A1[0])+" \n 2.giden ağırlıklar:"+str(self.A1[1])+" \n 3.giden ağırlıklar:"+str(self.A2[0])+" "+str(self.A2[1])+"\nBiaslar 1:{} 2:{} 3:{}".format(self.ilkadimbias[0],self.ilkadimbias[1],self.ikincibias)+"\n"
        return self.tbstring
    def calistir(self):        
        for i in range(epok):
            for j in range(len(giris)):
                if j!=satir:
                    if (i==epok-1):
                        self.a.append([j,str(self.ileri(giris[j]))[1:-1]])                        
                    self.ögretici(giris[j],cikis[j])
        self.degiskenler()
        self.yayma.emit()
        self.trigger.emit()
    def geta(self):
        return self.a
    def threadfonksiyon(self):
        t1=threading.Thread(target=self.calistir)
        t1.start()
    def sifirla(self):
        self.ilkadimbias=np.array(([-0.24,-2.4]),dtype=float)
        self.ikincibias=np.array(([-2.12]),dtype=float)
        self.A1=np.array(([-2.11,1.83,1.49],[0.69,1.12,1.97]),dtype=float)
        self.A2=np.array(([-2.89],[-1.36]),dtype=float)
        self.a.clear()
        self.yayma.emit()
# giris ve çıkış değerleri
giris=np.array(([0,0,0],[0,0,1],[0,1,0],[0,1,1],[1,0,0],[1,0,1],[1,1,0],[1,1,1]),dtype=float)
cikis=np.array(([0],[1],[0],[0],[0],[0],[1],[1]),dtype=float)
class setupUi(QtWidgets.QMainWindow):
    tbtext=""
    SA=Sinir_Agi()
    def __init__(self):
        #  Pyqt fonksiyonları
        super(setupUi,self).__init__()
        self.ui=Ui_MainWindow()
        self.ui.setupUi(self)
        self.model = QStandardItemModel(self)
        global epok
        self.SA.trigger.connect(self.butonac)
        self.SA.yayma.connect(self.tablogirdi)
        epok=self.ui.spinBox.value()
        self.ui.pushButton_3.setEnabled(False)
        self.ui.spinBox.valueChanged.connect(self.valuechange)
        self.ui.pushButton_2.clicked.connect(self.tiklandi)
        self.ui.pushButton_3.clicked.connect(self.test)
        self.ui.pushButton.clicked.connect(self.sifirlacagir)
        self.model.setHorizontalHeaderLabels(['X1', 'X2', 'X3','Y','DeltaY'])
        self.ui.tableView.setModel(self.model)
        #tabloya giriş ve çıkış değerlerini yazar
        for i in giris:
            row = []
            for item in i:
                cell = QStandardItem(str(item))
                row.append(cell)
            self.model.appendRow(row)
        for i in range(self.model.rowCount()):
            row = ""
            row = QStandardItem(str(cikis[i][0]))
            self.model.setItem(i,3,row)
        self.show()
        self.ui.tableView.selectionModel().selectionChanged.connect(self.satirata)        
        self.ui.tableView.resizeColumnsToContents()
        #tabloya giriş ve çıkış değerlerini yazar
    #seçilen satırın indisini tutar
    def tablogirdi(self):
        if len(self.SA.geta())==0:
            for i in range(8):
                hucre = QStandardItem("")
                self.model.setItem(i,4,hucre)
        else:
            for i in self.SA.geta():
                hucre = QStandardItem(str(i[1]))
                self.model.setItem(i[0],4,hucre)
                self.ui.tableView.resizeColumnsToContents()
    def sifirlacagir(self):
        self.ui.pushButton_3.setEnabled(False)
        self.SA.sifirla()
    def butonac(self):
        self.ui.pushButton_3.setEnabled(True)
        degiskenler=self.SA.degiskenler()
        self.yazdirma(degiskenler)  
    def satirata(self):
        secili=self.ui.tableView.selectionModel().selectedIndexes()
        global satir
        if len(secili)!=0:
            for i in sorted(secili):
                satir=i.row()
    def test(self):
        testveri=self.SA.test()
        self.yazdirma(testveri)
    def tiklandi(self):
        self.ui.pushButton_3.setEnabled(False)
        self.SA.threadfonksiyon()
    def valuechange(self):
        global epok
        self.ui.pushButton_3.setEnabled(False)
        epok=self.ui.spinBox.value()
    def yazdirma(self,yazi):
        self.ui.textBrowser.setText(str(yazi))
app = QtWidgets.QApplication(sys.argv)
app.setStyle("Fusion")
ex = setupUi()
ex.show()
sys.exit(app.exec())
