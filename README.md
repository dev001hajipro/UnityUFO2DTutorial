# UFO 2D Tutorial
Unity公式の [UFO 2D Tutorial](https://unity3d.com/jp/learn/tutorials/s/2d-ufo-tutorial)をベースに作成。


## 変更点
- 画像はoepngameartのspace-shooter-reduxを使用

### UnityとLINQ
UnityのTransformオブジェクトは[IEnumerable<T>](https://msdn.microsoft.com/ja-jp/library/9eekhta0(v=vs.110).aspx)ではないので、`.Cast<Transform>`でキャストするとLinqが使える。
```
using System.Linq;


	bool KilledAllEnemies ()
	{
		var pickups = GameObject.Find ("Pickups").transform.Cast<Transform> ();
		int activeCounts = pickups.Count (o => o.gameObject.activeSelf);
		return (activeCounts == 0);
	}
```

## Images
https://opengameart.org/content/space-shooter-redux
LICENSE(s): CC0

## SE
create by BFxr.