using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterWaypointMovement : MonoBehaviour
{
    [Header("移動速度")]
    public float moveSpeed = 4f;

    [Header("路徑座標點 (Vector2 陣列)")]
    // 利用 Vector2 陣列定義動作流程各階段的目的地
    public Vector2[] targetWaypoints;

    private int currentPointIndex = 0;
    private bool isFinished = false;

    void Start()
    {
        if (targetWaypoints == null || targetWaypoints.Length == 0)
        {
            Vector2 startPos = transform.position;

            targetWaypoints = new Vector2[]
            {
                startPos + new Vector2(-2f, 0f),   
                startPos + new Vector2(3f, 0f),
                startPos + new Vector2(7f, 3f),   
                startPos + new Vector2(11f, 0f)   
            };
        }
    }

    void Update()
    {
        if (isFinished || targetWaypoints.Length == 0) return;

        // 目標路徑點 (轉換為 Vector3 以便給 Transform 使用)
        Vector3 targetPos = new Vector3(targetWaypoints[currentPointIndex].x, targetWaypoints[currentPointIndex].y, transform.position.z);

        // 使用 Vector3.MoveTowards 進行平滑等速移動
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // 取得往目標移動的方向差
        float directionX = targetPos.x - transform.position.x;

        // 根據目標點的方向自動翻轉
        if (directionX < -0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = false;  // 目標在左邊，面向左
        }
        else if (directionX > 0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = true; // 目標在右邊，面向右
        }

        // 判斷是否抵達目前點 (距離極小時切換至下一點)
        if (Vector2.Distance(transform.position, targetWaypoints[currentPointIndex]) < 0.05f)
        {
            currentPointIndex++;

            // 檢查是否已走完整個陣列
            if (currentPointIndex >= targetWaypoints.Length)
            {
                isFinished = true;
                Debug.Log("已抵達終點！");
            }
        }
    }

}