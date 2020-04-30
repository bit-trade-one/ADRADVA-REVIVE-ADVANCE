# REVIVE USB ADVANCE

## HIDブートローダ書き込みソフト（HIDBootLoaderPIC32.exe）の使い方

### 1. このソフトで何が出来るのか

REVIVE USB ADVANCEはMicrochip社のPICと言うマイコンを用いて作られています。  
通常、PICマイコンにソフトを書き込む為には「ライタ」と呼ばれる書き込み装置が必要です。  
（Microchip社が出しているPICkitや、秋月電子のキットであるAKI-PICプログラマーなどが有名です）  

このソフトを用いれば、特別なライタを必要とせず、USBから直接マイコンのソフトを書き換える事ができます。  
ただし、その為にはマイコンにBootLoaderと呼ばれる特別なソフトがあらかじめ書き込まれている必要があり、またUSB経由で書き込むソフトもBootLoaderに対応したものになっていなければなりません。  
あらかじめ書き込まれるBootLoader自体は、「ライタ」で書き込まなければなりません。  

REVIVE USB ADVANCEに付属しているマイコンにはこのBootLoaderと言う特別なソフトがあらかじめ書かれています。よって、特別なライタをお持ちでなくてもUSB経由でソフトを書き込むことができます。  
また、GitHubで公開されているREVIVE USB ADVANCE用のソフトはこのBootLoaderでの書き込みに対応したソフトになっています。  

このBootLoaderを使うことで、USB経由で簡単にソフトを書き換えて、REVIVE USB ADVANCEのソフトを様々に書き換える事ができます。  

### 2. 準備

[こちら](https://github.com/bit-trade-one/ADRADVA-REVIVE-ADVANCE/raw/master/Writing-Tool/HIDBootLoaderPIC32.exe)からHIDBootLoaderPIC32.exeをダウンロードします。  

書き込みたいソフトもダウンロードしておきます。  

### 3. ソフトの書き込み

最初に、設定ツールからREVIVE USB ADVANCEをBOOTモードにします。  
![](http://bit-trade-one.co.jp/wp/wp-content/uploads/2020/04/01soft.png)  

中央下の「Firmware Update」ボタンをクリックしてください。  
![](http://bit-trade-one.co.jp/wp/wp-content/uploads/2020/04/02update.png)  

するとこのようにダイアログが表示されます。  
OKをクリックすると、REVIVE USB ADVANCEがBOOTモードになります。

HIDBootLoaderPIC32.exeを立ち上げます。  
![](http://bit-trade-one.co.jp/wp/wp-content/uploads/2020/04/03HIDTool.png)  

「Connect」をクリックして、BOOTモードのREVIVE USB ADVANCEに接続します。  
![](http://bit-trade-one.co.jp/wp/wp-content/uploads/2020/04/035connect.png)  

デバイスが認識されると上図の様に「Device connected」と表示され、その下にブートローダのバージョン番号が表示されます。  

初めてBOOTモードで接続した時には、自動的にPCにドライバがインストールされます。（約１分程時間かかります）  


「Load Hex File」を押します。  
書き込みたいHexファイルを選択します。  
![](http://bit-trade-one.co.jp/wp/wp-content/uploads/2020/04/04choose.png)  

「Write Hex File」を押します。  
![](http://bit-trade-one.co.jp/wp/wp-content/uploads/2020/04/045write.png)  


ソフトが書き込まれます。  
下図の状態になったら書き込み完了です。  
![](http://bit-trade-one.co.jp/wp/wp-content/uploads/2020/04/05Program.png) 

USBケーブルを抜き差しすると、書き込んだソフトが起動します。  

