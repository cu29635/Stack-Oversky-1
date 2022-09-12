using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public int limitY = -10;                      //�ּ� y��ǥ
    public int sign = 1;                    //��� ���� (����� ������, ������ ����)
    public float speed = 0.1f;              //����� �����̴� �ӵ�
    public bool isDown = false;             //����� ����߸��� ���� �����ϴ� ����
    private Rigidbody2D rigid;              //RibidBody �Ӽ� ������ ����
    public Vector3 startPos;                //���� ��ǥ
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();    //RigidBody �Ӽ� ������
        startPos = this.transform.position;     //�ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        if (isDown)//����
            rigid.constraints = RigidbodyConstraints2D.None;
        else//�� ������
        {
            if (this.transform.position.x > startPos.x + 2 || this.transform.position.x < startPos.x - 2) //������ ���� �������κ��� +-2
                sign *= -1;
            this.transform.position += new Vector3(speed * sign, 0, 0);
        }
        Under();
    }
    void Under()//���� y��ǥ ���� �������� ������Ʈ ����
    {
        if(this.transform.position.y < limitY)
        {
            Destroy(gameObject);
        }
    }
}
