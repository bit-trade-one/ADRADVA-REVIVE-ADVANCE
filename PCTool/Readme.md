# REVIVE USB ADVANCE Configuration Toolの使い方

## 1. 概要

ここでは、REVIVE USB ADVANCEのピン設定ツール、REVIVE USB ADVANCE Configuration Toolの使い方を紹介します。  
REVIVE USB ADVANCE Configuration Toolを用いると、各デジタルピンに「マウス」「キーボード」「ジョイパッド」のキーを、  
各アナログピンに「ジョイパッドアナログ6軸」「ジョイパッドSLIDER」「マウスカーソル移動X/Y」の機能を様々な組み合わせで登録する事が出来ます。  
Configuration Toolを用いて行った設定はREVIVE USB ADVANCEのチップの中に記憶されます。  
以後はConfiguration Toolを立ち上げる事無く動作します。（常駐ソフトも必要無し）  

## 2. 設定方法

### 2.1 REVIVE USB ADVANCEの立ち上げ

REVIVE USB ADVANCE Configuration Toolを立ち上げ、REVIVE USB ADVANCEを接続すると、自動的にデバイスが認識され、中央のボードの表示が以下のように明るくなります。  
![](https://bit-trade-one.co.jp/wp/wp-content/uploads/2019/09/AD_MAIN_ON.png)  
<!--(http://bit-trade-one.co.jp/wp/wp-content/uploads/2019/06/00wake.jpg)  -->
デバイスが認識されていないと、以下のように薄くなります。  
![](https://bit-trade-one.co.jp/wp/wp-content/uploads/2019/09/AD_MAIN_OFF.png)  
<!--![](http://bit-trade-one.co.jp/wp/wp-content/uploads/2019/06/01dis.jpg)  -->

<!--各画面の情報は以下のとおりです。  
![](http://bit-trade-one.co.jp/wp/wp-content/uploads/2019/06/02info.jpg)  -->
### 2.2 設定順序

設定は以下の順番で行ないます。  

    1. 設定するピンを選ぶ  
    2. デバイスタイプを選ぶ  
    3. 割当てを選ぶ  
    4. 「設定」ボタンを押す  

これを全てのピンに対して行っていきます。  

### 2.3 機能の設定
-----------------------------------------
### 2.3.1 アナログ機能

#### 1. 設定するピン番号の選択

まず、設定するピンを選びます。  
ピンは以下の選び方が出来ます。  

・左側の「ANALOG SETTING」タブ→「ピン番号」メニューで選択する  
![](https://bit-trade-one.co.jp/wp/wp-content/uploads/2019/09/2_1.png)  

・中央ボード周辺のピン番号を選択する  
※各ピンの下にある数値は、現在のピンの電圧値です。  
　接続したアナログデバイスを操作し、ここで値を読み取りながら設定値を書き込みます。  
![](https://bit-trade-one.co.jp/wp/wp-content/uploads/2019/09/2_2.png)  

・右側の「設定リスト」から設定したいピンを選択する。  
![](https://bit-trade-one.co.jp/wp/wp-content/uploads/2019/09/2_3.png)  

#### 2. 割当てを選択  

設定するピンを選んだ後、割当てを選択します。  
デバイスタイプの選択は左側の「設定」メニューから行ないます。  
![](https://bit-trade-one.co.jp/wp/wp-content/uploads/2019/09/2_4.png)  

#### 2.1. アナログジョイスティック・スライダー機能

アナログジョイスティックのX/Y/Z軸、各軸回りの回転、スライダー1chの計7ポートを設定できます。  
各ポートにはそれぞれの電圧・操作量に対し、最小値／中立値／最大値を設定できます。  
使用するジョイスティックやポテンショメータの特性に合わせ、操作する電圧範囲や出力操作量の範囲を  
自由に設定できます。  
![](https://bit-trade-one.co.jp/wp/wp-content/uploads/2019/09/2_5.png)  

#### 2.1.1. 電圧設定

最小電圧、中立電圧、最大電圧を設定できます。  
アナログスティックを最大に倒した時の電圧を最大／最小電圧に、無操作時の電圧を中立値に書き込むことで  
スティックごとの操作電圧範囲に合わせることが出来ます。

#### 2.1.2. 操作量設定

0V値、最小操作値、中立値、最大操作値、3.3V値を設定できます。

------------------------------------------------------

#### 2.2. マウスカーソル移動

マウスカーソルX／Y移動の2ポートを設定できます。  
各ポートには移動感度／中立位置／不感帯が設定できます。  

デバイスタイプの選択は左側の「設定」メニューから行ないます。  
![](https://bit-trade-one.co.jp/wp/wp-content/uploads/2019/09/2_6.png)  

#### 2.2.1. 感度

アナログ電圧値に応じてカーソルが動く際の感度を設定します。  
感度が高くなると、僅かな変動に反応したり、移動速度が高速になります。  

#### 2.2.2. キャリブレーション

「キャリブレーション」のチェックボックスをONにして設定を行うと、中立電圧、不感帯範囲を書き込みます。

#### 2.2.2.1. 中立位置調整

「中立位置調整」のチェックボックスをONにして設定を行うと、その時点でのアナログ電圧値を中立位置とします。
中立位置より電圧が上がると右／下、下がると左／上方向に動きます。  

#### 2.2.2.2. 不感帯

「不感帯」ボックスに設定値を書き込み設定を行うと、中立電圧から±設定値分の電圧以下の変動には反応しなくなります。  

-------------------------------------------

### 2.3.2 デジタル機能

#### 1. 設定するピン番号の選択

まず、設定するピンを選びます。  
ピンは以下の選び方が出来ます。  

・左側の「DIGITAL SETTING」タブ→「ピン番号」メニューで選択する  
![](https://bit-trade-one.co.jp/wp/wp-content/uploads/2019/09/3_1.png)  

・中央ボード周辺のピン番号を選択する  
![](https://bit-trade-one.co.jp/wp/wp-content/uploads/2019/09/3_2.png)  

・右側の「設定リスト」から設定したいピンを選択する。  
![](https://bit-trade-one.co.jp/wp/wp-content/uploads/2019/09/3_3.png)  


#### 2. デバイスタイプ／割当てを選択  

設定するピンを選んだ後、デバイスタイプ／割当てを選択します。  
デバイスタイプの選択はコンボボックスから行います。  

#### 2.1. マウス

マウスは以下の割当てから選ぶ事が出来ます。

 - 左クリック
 - 右クリック
 - ホイールクリック
 - ボタン4
 - ボタン5
 - 上移動
 - 下移動
 - 左移動
 - 右移動
 - ホイール上
 - ホイール下
 - カーソル速度変更

#### 2.1.1. 左クリック

左クリックに割当てられたピンがONになると、マウスの左クリックが押されます。  

#### 2.1.2. 右クリック

右クリックに割当てられたピンがONになると、マウスの右クリックが押されます。  

#### 2.1.3. ホイールクリック

ホイールクリックに割当てられたピンがONになると、マウスのホイール（真ん中ボタン）が押されます。  

#### 2.1.4. ボタン4／ボタン5

主にWebブラウザなどで「戻る」/「進む」に割り当てられているボタンです。  
各ボタンに割り当てられたピンがONになると、ブラウザが反応しページ送りが出来ます。

#### 2.1.5. 上移動／下移動／左移動／右移動

各移動に割当てられたピンがONになると、マウスカーソルが設定した方向に移動します。  
マウスカーソルのスピードは「移動速度」で設定出来ます。  
デフォルトは50で、1～255の範囲で設定し、値が小さい程カーソル速度は遅く、値が大きいほどカーソル速度は早くなります。  
![](https://bit-trade-one.co.jp/wp/wp-content/uploads/2019/09/3_4.png)  

#### 2.1.6. ホイール上／ホイール下

各ホイールに割当てられたピンがONになると、マウスのホイールを上または下に回したのと同じ動作をします。  
ホイールの速度は「移動速度」で設定出来ます。デフォルトは50で、1～255の範囲で設定し、値が小さいほど、ホイール速度は遅く、値が大きいほどホイール速度は早くなります。  

#### 2.1.7. カーソル速度変更

カーソル速度変更に割当てられたピンがONになると、上移動／下移動／左移動／右移動のカーソル速度がこのピンに設定された値に変更されます。  
この変更は、このボタンが押されている間のみ、有効になります。  
01ピンにカーソル左移動を移動速度50で、02ピンにカーソル速度変更を移動速度100で設定すると、01ピンだけを押した場合には左に速度50で、02ピンを押しながら01ピンを押した場合には速度が100になります。  

#### 2.2. キーボード

割当てのCtrl／Shift／Alt／Winのチェックボックスにチェックを入れ、「ここに入力」の所でキーを入力し、設定すると、ピンにその動作が割当てられます。  
![](https://bit-trade-one.co.jp/wp/wp-content/uploads/2019/09/3_5.png)  
例えば、「CTRL + ALT + DEL」を設定したい場合には、[Ctrl]と[Alt]にチェックを入れ、「ここに入力」の所で「Delキー」を押し、「設定」を押します。  
そのピンがONになると、CTRL + ALT + DELが押されます。  

#### 2.3. ジョイパッド

アナログ6軸±(最大or最小)／アナログスライダー±(最大or最小)／ハットスイッチ上下左右／ボタン1～15の中からそのピンに対応させたい物を選んでチェックを入れます。  
チェックを入れたもの全てが反応する様になります。  
例えば、「ボタン１」と「ボタン３」にチェックを入れた場合、そのピンをONにすると、「ボタン１／３」が同時におされます。  
![](https://bit-trade-one.co.jp/wp/wp-content/uploads/2019/09/3_6.png)  

なお、アナログ6軸、スライダーについてアナログピンに同じ機能を割り当てている場合は、アナログ入力が優先されます。  
また、同じアナログ軸において＋に設定されたピンと－に設定されたピンを同時に反応させた場合、出力値は中立値（通常128）となります。

## ex. 開発環境

このソフトウェアは、以下の環境で開発されています。
- Microsoft Visual C# 2010 Express
