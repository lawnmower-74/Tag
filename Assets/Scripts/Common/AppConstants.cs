/// <summary>定数を管理</summary>
public static class AppConstants
{
    /// <summary>PlayerPrefs(プレイ時間)の取得キー</summary>
    public const string PLAY_TIME_KEY = "PlayTime";

    /// <summary>デフォルトのプレイ時間</summary>
    public const int DEFAULT_PLAY_MINUTES = 3;

    /// <summary>最小プレイ時間</summary>
    public const int MINIMUM_PLAY_MINUTES = 1;

    /// <summary>最大プレイ時間</summary>
    public const int MAX_PLAY_MINUTES = 5;

    /// <summary>ポーション効果の説明パネルが表示されたかどうかのキー</summary>
    public const string POTION_PANEL_SHOWN_KEY = "PotionPanelShown";
}
