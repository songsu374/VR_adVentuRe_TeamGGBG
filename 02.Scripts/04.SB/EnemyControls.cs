using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    public Transform target;
    public Vector3 direction;
    public float velocity;
    public float default_velocity;
    public float accelaration;
    public Vector3 default_direction;

    // Start is called before the first frame update
    void Start()
    {
        // �ڵ����� ������ ���� ����
        default_direction.x = Random.Range(-1.0f, 1.0f);
        default_direction.y = Random.Range(-1.0f, 1.0f);

        // ���ӵ� ���� (���� ���� ����, �Ÿ� �� ����ؼ� ������ ��)
        accelaration = 0.1f;
        default_velocity = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        // Player�� ���� ��ġ�� �޾ƿ��� Object
        target = GameObject.Find("Player").transform;
        // Player�� ��ü ���� �Ÿ� ���
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= 1.0f)
        {
            MoveToTarget();
            // ���� �Ÿ��ȿ� �ִٰ� �ٽ� �־����� ��, �����Ÿ��ȿ� �־��� player�� �������� ������
            default_direction = direction;
        }
        // �����Ÿ� �ۿ� ���� ��, �ӵ� �ʱ�ȭ�ϰ� �ش� �������� ���� 
        else
        {
            velocity = 0.0f;
            this.transform.position = new Vector3(transform.position.x + (default_direction.x * default_velocity),
                                                   transform.position.y + (default_direction.y * default_velocity),
                                                   transform.position.z);
        }

    }
    public void MoveToTarget()
    {
        // Player�� ��ġ�� �� ��ü�� ��ġ�� ���� ���� ����ȭ �Ѵ�.
        direction = (target.position - transform.position).normalized;

        // �ʰ� �ƴ� �� ���������� ���ӵ� ����Ͽ� �ӵ� ����
        velocity = (velocity + accelaration * Time.deltaTime);

        // �ش� �������� ����
        this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                               transform.position.y + (direction.y * velocity),
                                                  transform.position.z);


    }
}