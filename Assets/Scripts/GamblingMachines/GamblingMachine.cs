using UnityEngine;

public abstract class GamblingMachine : MonoBehaviour
{

    [SerializeField] private int _buildCost;
    [SerializeField] private int _maintCost;
    [SerializeField] private int _numSeats;

    protected int BuildCost => _buildCost;
    protected int MaintCost => _maintCost;
    protected int NumSeats => _numSeats;

    public int _currentPlayers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public virtual bool IsFull()
    {
        if (_currentPlayers == NumSeats)
            return true;

        return false;
    }

    public virtual bool TryUsing()
    {
        if (IsFull())
            return false;

        return true;
    }

    protected abstract void StartGame();



}
