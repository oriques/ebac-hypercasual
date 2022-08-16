using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform container;

    public List<GameObject> levels;

    public List<LevelPiecesBasedSetup> levelPiecesBasedSetups;

    [SerializeField] private int _index;
    private GameObject _currentlevel;

    [SerializeField] private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private LevelPiecesBasedSetup _currSetup;


    private void Awake()
    {
       //SpawnNextLevel();
        CreateLevel();
    }

    private void SpawnNextLevel()
    {
        if(_currentlevel != null)
        {
            Destroy(_currentlevel);
            _index++;

            if(_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }

        _currentlevel = Instantiate(levels[_index], container);
        _currentlevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    #region

    private void CreateLevel()
    {
        CleanSpawnedPieces();

        if (_currSetup != null)
        {
            _index++;

            if (_index >= levelPiecesBasedSetups.Count)
            {
                ResetLevelIndex();
            }
        }

        _currSetup = levelPiecesBasedSetups[_index];

        for (int i = 0; i < _currSetup.piecesStartNumber; i++)
        {
            CreateLevelPiece(_currSetup.levelPiecesStart);
        } 
        
        for (int i = 0; i < _currSetup.piecesNumber; i++)
        {
            CreateLevelPiece(_currSetup.levelPieces);
        }  
        
        for (int i = 0; i < _currSetup.piecesEndNumber; i++)
        {
            CreateLevelPiece(_currSetup.levelPiecesEnd);
        }

    }

    private void CreateLevelPiece(List<LevelPieceBase> list )
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }

        else
        {
            spawnedPiece.transform.localPosition = Vector3.zero;
        }

        foreach (var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.Instance.GetSetupByType(_currSetup.artType).gameObject);
        }


        _spawnedPieces.Add(spawnedPiece);

    }

     private void CleanSpawnedPieces()
     {
        for (int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
     }


    #endregion

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D ))
        {
            CreateLevel();
        }
    }
}
