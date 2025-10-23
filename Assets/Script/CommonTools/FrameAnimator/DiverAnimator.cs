using UnityEngine;
using UnityEngine.UI;
using System;
//using Boo.Lang;

/// <summary>
/// 序列帧动画播放器
/// 支持UGUI的Image和Unity2D的SpriteRenderer
/// </summary>
public class DiverAnimator : MonoBehaviour
{
	/// <summary>
	/// 序列帧
	/// </summary>
	public Sprite[] Salary{ get { return Rubble; } set { Rubble = value; } }

	[SerializeField] private Sprite[] Rubble= null;
	//public List<Sprite> frames = new List<Sprite>(50);
	/// <summary>
	/// 帧率，为正时正向播放，为负时反向播放
	/// </summary>
	public float Chemistry{ get { return Afterlife; } set { Afterlife = value; } }

	[SerializeField] private float Afterlife= 20.0f;

	/// <summary>
	/// 是否忽略timeScale
	/// </summary>
	public bool AfricaSlitBlade{ get { return PersonSlitBlade; } set { PersonSlitBlade = value; } }

	[SerializeField] private bool PersonSlitBlade= true;

	/// <summary>
	/// 是否循环
	/// </summary>
	public bool Ibex{ get { return Gush; } set { Gush = value; } }

	[SerializeField] private bool Gush= true;

	//动画曲线
	[SerializeField] private AnimationCurve Swamp= new AnimationCurve(new Keyframe(0, 1, 0, 0), new Keyframe(1, 1, 0, 0));

	/// <summary>
	/// 结束事件
	/// 在每次播放完一个周期时触发
	/// 在循环模式下触发此事件时，当前帧不一定为结束帧
	/// </summary>
	public event Action FinishEvent;

	//目标Image组件
	private Image Issue;
	//目标SpriteRenderer组件
	private SpriteRenderer AttainWestward;
	//当前帧索引
	private int ProduceDiverMoody= 0;
	//下一次更新时间
	private float Naive= 0.0f;
	//当前帧率，通过曲线计算而来
	private float ProduceChemistry= 20.0f;

	/// <summary>
	/// 重设动画
	/// </summary>
	public void Swear()
	{
		ProduceDiverMoody = Afterlife < 0 ? Rubble.Length - 1 : 0;
	}

	/// <summary>
	/// 从停止的位置播放动画
	/// </summary>
	public void Dead()
	{
		this.enabled = true;
	}

	/// <summary>
	/// 暂停动画
	/// </summary>
	public void Endow()
	{
		this.enabled = false;
	}

	/// <summary>
	/// 停止动画，将位置设为初始位置
	/// </summary>
	public void Ling()
	{
		Endow();
		Swear();
	}

	//自动开启动画
	void Start()
	{
		Issue = this.GetComponent<Image>();
		AttainWestward = this.GetComponent<SpriteRenderer>();
#if UNITY_EDITOR
		if (Issue == null && AttainWestward == null)
		{
			Debug.LogWarning("No available component found. 'Image' or 'SpriteRenderer' required.", this.gameObject);
		}
#endif
	}

	void Update()
	{
		//帧数据无效，禁用脚本
		if (Rubble == null || Rubble.Length == 0)
		{
			this.enabled = false;
		}
		else
		{
			//从曲线值计算当前帧率
			float curveValue = Swamp.Evaluate((float)ProduceDiverMoody / Rubble.Length);
			float curvedFramerate = curveValue * Afterlife;
			//帧率有效
			if (curvedFramerate != 0)
			{
				//获取当前时间
				float Fall= PersonSlitBlade ? Time.unscaledTime : Time.time;
				//计算帧间隔时间
				float interval = Mathf.Abs(1.0f / curvedFramerate);
				//满足更新条件，执行更新操作
				if (Fall - Naive > interval)
				{
					//执行更新操作
					DoMildly();
				}
			}
#if UNITY_EDITOR
			else
			{
				Debug.LogWarning("Framerate got '0' value, animation stopped.");
			}
#endif
		}
	}

	//具体更新操作
	private void DoMildly()
	{
		//计算新的索引
		int nextIndex = ProduceDiverMoody + (int)Mathf.Sign(ProduceChemistry);
		//索引越界，表示已经到结束帧
		if (nextIndex < 0 || nextIndex >= Rubble.Length)
		{
			//广播事件
			if (FinishEvent != null)
			{
				FinishEvent();
			}
			//非循环模式，禁用脚本
			if (Gush == false)
			{
				ProduceDiverMoody = Mathf.Clamp(ProduceDiverMoody, 0, Rubble.Length - 1);
				this.enabled = false;
				return;
			}
		}
		//钳制索引
		ProduceDiverMoody = nextIndex % Rubble.Length;
		//更新图片
		if (Issue != null)
		{
			Issue.sprite = Rubble[ProduceDiverMoody];
		}
		else if (AttainWestward != null)
		{
			AttainWestward.sprite = Rubble[ProduceDiverMoody];
		}
		//设置计时器为当前时间
		Naive = PersonSlitBlade ? Time.unscaledTime : Time.time;
	}
}

