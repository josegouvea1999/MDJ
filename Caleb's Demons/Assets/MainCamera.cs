using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float CameraSpeed = 5, stepX = 10, stepY = 10;
    public bool left, right, up, down, reset, init = true;
    public Vector3 resetPos;
    public Vector3 newPos;

    public static Vector3 AccelDecelInterpolation(Vector3 start, Vector3 end, float t)
    {
        float x = end.x - start.x;
        float y = end.y - start.y;
        float z = end.z - start.z;

        float newT = (Mathf.Cos((t + 1) * Mathf.PI) / 2) + 0.5f;

        x *= newT;
        y *= newT;
        z *= newT;

        Vector3 retVector = new Vector3(start.x + x, start.y + y, start.z + z);

        return retVector;
    }

    public void MoveLeft()
    {
        if (init)
        {
            newPos = transform.position + new Vector3(-stepX, 0.0f, 0.0f);
            init = false;
        }

        float disFromCamera = Vector3.Distance(transform.position, newPos);

        if (disFromCamera > 0.001f)
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * CameraSpeed);
        else
            left = init = false;
    }

    public void MoveRight()
    {
        if (init)
        {
            newPos = transform.position + new Vector3(stepX, 0.0f, 0.0f);
            init = false;
        }

        float disFromCamera = Vector3.Distance(transform.position, newPos);

        if (disFromCamera > 0.001f)
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * CameraSpeed);
        else
            right = init = false;
    }

    public void MoveUp()
    {
        if (init)
        {
            newPos = transform.position + new Vector3(0.0f, stepY, 0.0f);
            init = false;
        }

        float disFromCamera = Vector3.Distance(transform.position, newPos);

        if (disFromCamera > 0.001f)
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * CameraSpeed);
        else
            up = init = false;
    }

    public void MoveDown()
    {
        if (init)
        {
            newPos = transform.position + new Vector3(0.0f, -stepY, 0.0f);
            init = false;
        }

        float disFromCamera = Vector3.Distance(transform.position, newPos);

        if (disFromCamera > 0.001f)
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * CameraSpeed);
        else
            down = init = false;
    }

    public void ResetCamera()
    {
        transform.position = resetPos;
        reset = false;
    }


    void Update()
    {
        if (left)
            MoveLeft();

        else if (right)
            MoveRight();

        else if (up)
            MoveUp();

        else if (down)
            MoveDown();

        else if (reset)
            ResetCamera();
    }

    void Start()
    {
        resetPos = transform.position;
    }
}
