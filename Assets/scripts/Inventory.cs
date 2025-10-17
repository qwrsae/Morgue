using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


public class Inventory : MonoBehaviour
{
    private Image[] _images;
    private Color _color;

    [SerializeField] private List<Objects> _objects;

    public List<Objects> Objects { get => _objects; }

    void Start()
    {
        _images = GetComponentsInChildren<Image>().Skip(1).ToArray();
        _objects.Add(global::Objects.empty);
        _color = _images[0].color;
    }

    public void InputSlot(Sprite sprite, Objects name)
    {
        foreach (var im in _images)
        {
            if (im.sprite == null)
            {
                im.sprite = sprite;
                im.color = Color.white;
                _objects.Add(name);
                return;
            }
        }
    }
    public void ClierSlot(Objects obj)
    {
        int slot = _objects.Count(f => f == obj);
        _objects.Remove(obj);
        _images[slot -1].sprite = null;
        _images[slot - 1].color = _color;
    }

}
