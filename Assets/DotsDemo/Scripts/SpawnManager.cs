
using System;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private int gridSize;

    private BlobAssetStore _blob;

    [SerializeField] private float offset;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEntities();
        }
    }

    private void SpawnEntities()
    {
        _blob = new BlobAssetStore();

        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, _blob);
        var entity =  GameObjectConversionUtility.ConvertGameObjectHierarchy(_prefabToSpawn, settings);
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;


        for (var i = 0; i < gridSize; i++) 
        {
            for (var j = 0; j < gridSize; j++)
            {
                var instance = entityManager.Instantiate(entity);
                float3 position = new float3(0, i, j);

                entityManager.SetComponentData(instance, new Translation { Value = position });
            }
        }
        
        
    }

    private void OnDestroy()
    {
        _blob.Dispose();
    }
}
