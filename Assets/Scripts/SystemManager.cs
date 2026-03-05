using UnityEngine;

public class SystemManager : MonoBehaviour
{
   static SystemManager instance = null;

   public SystemManager Instace
   {
      get
      {
         return instance;
      }
   }

   private void Awake()
   {
      if(instance != null)
      {
         Debug.LogError("SystemManager error! singleton error");
         Destroy(gameObject);
         return;
      }

      instance = this;

   }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {

   }

   void Update()
   {

   }







}
