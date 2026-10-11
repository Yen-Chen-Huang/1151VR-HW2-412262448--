# 1151VR-HW2-412262448--
<img width="2560" height="1440" alt="image" src="https://github.com/user-attachments/assets/ef3df04d-fbcb-41fc-8d04-3c44b51fba1d" />

github連結
https://github.com/Yen-Chen-Huang/1151VR-HW2-412262448--.git

youtube連結
https://youtu.be/NoYm87o2F0s

說明製作流程和相關操作

1. 場景與角色配置
	
	建立 2D 專案：在 Unity 中建立 2D 模板專案，並配置攝影機與背景顏色。

	角色與平台建立：匯入 2D 角色圖片（Sprite），建立角色 GameObject 並掛載 C#檔案及Sprite Renderer；利用內建 2D Square 建立地面與右側目標跳台作為參照物。

3. 核心邏輯設計（Vector 與陣列應用）
	
	路徑規劃（Vector2 陣列）：
宣告 Vector2[] targetWaypoints 陣列儲存動作序列的關鍵節點，依序設定為：往左走 → 轉向往右走 → 往右上起跳 → 往右下落至終點平台。

	移動與距離判斷（Vector 運算）：
在 Update() 中使用 Vector3.MoveTowards() 讓角色朝當前目標點平滑前進，並使用 Vector2.Distance() 判斷是否抵達；抵達後將陣列索引 +1 切換至下一動，走完陣列即判定抵達終點。

	動態左右轉向：
利用目標點與角色位置的 X 軸差值判斷前進方向，動態切換 SpriteRenderer.flipX 實現移動時自動轉頭。

5. 操作方式
   
	點擊 Unity 上方 Play執行

