# UFO 2D Tutorial
Unity公式の [UFO 2D Tutorial](https://unity3d.com/jp/learn/tutorials/s/2d-ufo-tutorial)をベースに作成。

# WebGL版デモ
https://dev001hajipro.github.io/UnityUFO2DTutorial/

## 公式チュートリアルとの違い
- 画像は、[oepngameart space-shooter-redux](https://opengameart.org/content/space-shooter-redux)を使用

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
