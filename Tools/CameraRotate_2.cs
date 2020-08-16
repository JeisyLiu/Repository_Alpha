using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class CameraRotate_2:MonoBehaviour
{
    //y轴最大,最小角度
    public float y_min = 5;
    public float y_max = 160;

    private float move_x = 0.0f;
    private float move_y = 0.0f;

    //旋转速度
    public float speed = 30.0f;
    
    //观察目标
    public Transform Target;

    /// <summary>
    /// 和观察目标之间的距离
    /// </summary>
    public float Distance = 8;

    void Update()
    {
        //获取鼠标的xy位移量
        move_x += Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        move_y -= Input.GetAxis("Mouse Y") * speed * Time.deltaTime;

        //将y的移动量固定到某个曲线 y_min < move_y < y_max
        move_y = ClampAngle(move_y, y_min, y_max);

        //通过四元数运算，将xy的轴偏移量转换成 旋转 对象
        Quaternion rotation = Quaternion.Euler(move_y, move_x, 0);

        //将构建好的旋转对象赋值给相机，实现旋转
        this.transform.rotation = rotation;

        //然后通过之前设定的Distance（距离参数）  将相机的位置进行重新定位
        Vector3 mPosition = rotation * new Vector3(0.0F, 0.0F, -Distance) + Target.position;


        transform.position = mPosition;

    }

    /// <summary>
    /// 角度限制
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}

