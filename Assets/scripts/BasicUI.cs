using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicUI : MonoBehaviour {
    void OnGUI() {
        int posX = 10;
        int poxY = 10;
        int width = 100;
        int height = 30;
        int buffer = 10;

        List<string> itemList = Managers.Inventory.GetItemList();
        if (itemList.Count == 0) {
            GUI.Box(new Rect(posX, poxY, width, height), "No Items");
        }
        foreach (string item in itemList) {
            int count = Managers.Inventory.GetItemCount(item);
            Texture2D image = Resources.Load<Texture2D>($"Icons/{item}");
            GUI.Box(new Rect(posX, poxY, width, height), new GUIContent($"({count})", image));
            posX += width + buffer;
        }

        string equipped = Managers.Inventory.equippedItem;
        if (equipped != null) {
            posX = Screen.width - (width + buffer);
            Texture2D image = Resources.Load($"Icons/{equipped}") as Texture2D;
            GUI.Box(new Rect(posX, poxY, width, height), new GUIContent("Equipped", image));
        }
        posX = 10;
        poxY = height + buffer;
        foreach (string item in itemList) {
            if (GUI.Button(new Rect(posX, poxY, width, height), $"Equip {item}")) {
                Managers.Inventory.EquipItem(item);
            }
            
            if (item == "health") {
                if (GUI.Button(new Rect(posX, poxY + height + buffer, width, height), "Use Health")) {
                    Managers.Inventory.ConsumeItem("health");
                    Managers.Player.ChangeHealth(25);
                }
            }

            posX += width + buffer;
        }
    }
}