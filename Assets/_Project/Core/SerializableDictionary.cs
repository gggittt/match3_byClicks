using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project.Core
{
[System.Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] List<SerializedDictionaryKVPProps<TKey, TValue>> dictionaryList = new();

    void ISerializationCallbackReceiver.OnBeforeSerialize( )
    {
        foreach ( KeyValuePair<TKey, TValue> kVP in this )
        {
            if ( dictionaryList.FirstOrDefault( value => Comparer.Equals( value.Key, kVP.Key ) ) is { } serializedKVP )
            {
                serializedKVP.Value = kVP.Value;
            }
            else
            {
                dictionaryList.Add( kVP );
            }
        }

        dictionaryList.RemoveAll( value => ContainsKey( value.Key ) == false );

        for ( int i = 0; i < dictionaryList.Count; i++ )
        {
            dictionaryList[ i ].index = i;
        }
    }

    void ISerializationCallbackReceiver.OnAfterDeserialize( )
    {
        Clear();

        dictionaryList.RemoveAll( r => r.Key == null );

        foreach ( SerializedDictionaryKVPProps<TKey, TValue> serializedKVP in dictionaryList )
        {
            if ( !( serializedKVP.isKeyDuplicated = ContainsKey( serializedKVP.Key ) ) )
            {
                Add( serializedKVP.Key, serializedKVP.Value );
            }
        }
    }

    public new TValue this[ TKey key ] //refactor delete?
    {
        get
        {
#if UNITY_EDITOR
            if ( ContainsKey( key ) )
            {
                var duplicateKeysWithCount = dictionaryList.GroupBy( item => item.Key )
                   .Where( group => group.Count() > 1 )
                   .Select( group => new { Key = group.Key, Count = group.Count() } );

                foreach ( var duplicatedKey in duplicateKeysWithCount )
                {
                    Debug.LogError( $"Key '{duplicatedKey.Key}' is duplicated {duplicatedKey.Count} times in the dictionary." );
                }

                return base[ key ];
            }
            else
            {
                Debug.LogError( $"Key '{key}' not found in dictionary." );
                return default(TValue);
            }
#else
                return base[key];
#endif
        }
    }

    [System.Serializable]
    public class SerializedDictionaryKVPProps<TypeKey, TypeValue>
    {
        public TypeKey Key;
        public TypeValue Value;

        public int index; //refactor delete?
        public bool isKeyDuplicated;

        public SerializedDictionaryKVPProps( TypeKey key, TypeValue value )
        {
            Key = key;
            Value = value;
        }

        public static implicit operator SerializedDictionaryKVPProps<TypeKey, TypeValue>( KeyValuePair<TypeKey, TypeValue> kvp )
            => new SerializedDictionaryKVPProps<TypeKey, TypeValue>( kvp.Key, kvp.Value );

        public static implicit operator KeyValuePair<TypeKey, TypeValue>( SerializedDictionaryKVPProps<TypeKey, TypeValue> kvp )
            => new KeyValuePair<TypeKey, TypeValue>( kvp.Key, kvp.Value );
    }
}
}