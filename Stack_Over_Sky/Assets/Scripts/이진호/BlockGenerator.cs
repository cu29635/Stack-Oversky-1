using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bolckPrefab;      //�� ������ ���庯��
    GameObject blo1;                    //������ idle �� �����
    GameObject blo2;                    //���� ����
    public float plusHeight = 1;        //�� ���� ���̸� �ø��� ����
    public float height1 = 3;           //���� ����
    public float height2 = 3;           //���� ����
    public float max_height = 3;
    float span = 0.5f;                  //������
    float delta1 = 0.5f;                //�� ���� ����
    float delta2 = 0.5f;                //�� ���� ����
    bool blockExist1 = false;           //�� ���� Ȯ��
    bool blockExist2 = false;           //�� ���� Ȯ��

    // Update is called once per frame
    void Update()
    {
        DeltaTime();//�� ����
        CreateBlock();//�� ����
        max_height = height1 > height2 ? height1 : height2;
    }

    void GetKEYDown1(GameObject b1)//�� ���� �Լ�
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            delta1 = 0.0f;
            b1.GetComponent<BlockController>().isDown = true;
            height1 += plusHeight;
            blockExist1 = false;
        }
    }

    void GetKEYDown2(GameObject b2)//�� ���� �Լ� 2
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            delta2 = 0.0f;
            b2.GetComponent<BlockController>().isDown = true;
            height2 += plusHeight;
            blockExist2 = false;
        }
    }

    void CreateBlock()
    {
        if (blockExist1 == false && this.span < this.delta1)//���� ���� �� bl1�� BlockController �Ӽ��� �����ͼ� ����
        {
            GameObject bl1 = Instantiate(bolckPrefab) as GameObject;
            bl1.transform.position = new Vector3(-3, height1, 0);
            bl1.GetComponent<BlockController>().startPos = new Vector3(-3, height1, 0);
            blo1 = bl1;
            blockExist1 = true;
        }
        if (blockExist2 == false && this.span < this.delta2)//���� ���� �� bl2�� BlockController �Ӽ��� �����ͼ� ����
        {
            GameObject bl2 = Instantiate(bolckPrefab) as GameObject;
            bl2.transform.position = new Vector3(3, height2, 0);
            bl2.GetComponent<BlockController>().startPos = new Vector3(3, height2, 0);
            bl2.GetComponent<BlockController>().sign *= -1;
            blo2 = bl2;
            blockExist2 = true;
        }
        if (blockExist1)//���� ������ ����
            GetKEYDown1(blo1);
        if (blockExist2)//���� ������ ����
            GetKEYDown2(blo2);
    }

    void DeltaTime()//�� ���� ������ �ֱ� ���� �ڵ� ���� 0.5��(��������)
    {
        delta1 += Time.deltaTime;
        delta2 += Time.deltaTime;
    }
}
