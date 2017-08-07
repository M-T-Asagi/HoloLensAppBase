# HoloLensAppBase
HoloLensアプリを制作する際、HoloToolKitなどをインポート・設定を毎回やるのは大変なので、テンプレート化しました。
UnityPackageはこちら https://1drv.ms/u/s!AuyMwbaOdrD0hleowsrIVTp3R58C でDLできます。 

♯ 利用に際し

+ HoloToolKitはMicrosoftのライセンス（詳しくはこちら https://github.com/Microsoft/HoloToolkit-Unity）である
+ 一応MITライセンスだがHoloToolKitのライセンスの変更に伴い変更する可能性がある
+ 個人製作程度を想定。商用規模での利用は想定されていません。
+ 機能追加・修正のご要望はissueへ
+ 機能追加・修正をしていただけるならPull-Reqへ

以上もろもろよろしくお願いいたします。

# 使い方

1. https://1drv.ms/u/s!AuyMwbaOdrD0hleowsrIVTp3R58C からUnityPackageをDL
2. 新規Unityプロジェクトを作成
3. パッケージをインポート
4. Pre, Mainをヒエラルキーに追加
5. Mainを非アクティブに

以上で最低限動作するはずです。
一応UnityEditor上でAirTapだけはシミュレートしていて、CustomSpatialMappingのObjectObserverには私の開発環境のデータが仕込まれているので、こちらを適宜お使いいただければ、UnitｙEditor上でも最低限の動作確認はできます。

## コンテンツの追加方法

5. Main以下、Anchorの中にコンテンツを追加。

以上です。

# Sharing Confirmについて

私の制作環境の都合上、アプリケーションの一番最初に『Sharingしますか？』というようなダイアログが出るようになっています。

『はい』を選ぶとIPアドレスの入力画面に飛びます。
こちらから任意のSharingServerへアクセスしてSharingできます。

こちらの初期値はPre内にあるBaseStatesのSharingServerAddressが適用されます。適宜書き換えてください。

『いいえ』を選ぶとそのままアプリケーションが開始されます。
Sharingはしません。

## Confirmが邪魔？

Pre内にあるPreManagerでConfirmの管理をしています。
適宜書き換えてください。

# SpectatorViewについて

すみません。動きません。

私もこちらが本命なので早めに直したいとは思っています。

現在、Main以下にSpectatorViewManagerが配置されてはいますが、非アクティブ化されているうえ、Activeにするとアプリケーションが問答無用でフリーズになるので問題が解決するまではご利用をお控えください。

また、こちらの問題の原因などわかりましたら誰か教えてください。


