using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImageEditor.Lib
{
    public class History<T>
    {
        public int HistoryDepth { get; set; }
        private List<T> SavedStates { get; set; }
        private int CurrentState;

        public History(int historyDepth)
        {
            this.HistoryDepth = historyDepth;
            this.SavedStates = new List<T>();
        }

        public void SaveState(T b)
        {
            if (CurrentState < SavedStates.Count - 1) {
                SavedStates.RemoveRange(CurrentState + 1, SavedStates.Count - CurrentState - 1);
            }
            if (SavedStates.Count == HistoryDepth) {
                SavedStates.RemoveAt(0);
            }
            SavedStates.Add(b);
            CurrentState = SavedStates.Count - 1;
        }

        public T GetState(int stateIndex)
        {
            if (stateIndex < 0 && stateIndex >= SavedStates.Count) {
                throw new ArgumentException("Неправильный индекс состояния");
            }
            return SavedStates[stateIndex];
        }

        public bool CanUndo()
        {
            return SavedStates.Count > 0 && CurrentState > 0;
        }

        public bool CanRedo()
        {
            return SavedStates.Count > 0 && CurrentState < SavedStates.Count - 1;
        }

        public T Undo()
        {
            return SavedStates[--CurrentState];
        }

        public T Redo()
        {
            return SavedStates[++CurrentState];
        }
    }
}
