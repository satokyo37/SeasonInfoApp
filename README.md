# SeasonInfoApp

季節と国を選ぶと、その月の特徴（気温・自然・文化など）をChatGPTから取得し、イメージ画像も同時に表示するC# Windowsフォームアプリケーションです。

## 🔧 機能

- 月と国を選択して、該当する季節情報を取得（OpenAI API使用）
- Unsplash APIを使って季節に関連した画像を表示
- シンプルなUI設計

## 🛠️ 技術スタック

- 言語: C#
- フレームワーク: Windows Forms (.NET Framework 4.8)
- API:
  - [OpenAI GPT-3.5](https://platform.openai.com/)
  - [Unsplash Image API](https://unsplash.com/developers)

## ⚙️ 使用方法

1. `app.config.sample` をコピーして `app.config` を作成
2. 中のAPIキー部分を自分のOpenAI/Unsplashのキーに置き換えてください

```xml
<add key="OpenAI_API_KEY" value="YOUR_OPENAI_API_KEY" />
<add key="UNSPLASH_API_KEY" value="YOUR_UNSPLASH_API_KEY" />
