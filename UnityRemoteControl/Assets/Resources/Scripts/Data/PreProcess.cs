﻿using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class PreProcess : MonoBehaviour
{
    public QuoteDB[] quotedb;

    public List<QuoteDB> loveDb = new List<QuoteDB>();
    public List<QuoteDB> lifeDb = new List<QuoteDB>();
    public List<QuoteDB> philosophyDb = new List<QuoteDB>();
    public List<QuoteDB> educationDb = new List<QuoteDB>();
    public List<QuoteDB> inspirationalDb = new List<QuoteDB>();
    public List<QuoteDB> artDb = new List<QuoteDB>();

    void Start()
    {
        Debug.Log("1");

        TextAsset quoteData = Resources.Load<TextAsset>("Database/budefason");
        string[] data = quoteData.text.Split(new char[] { '\n' });

        quotedb = new QuoteDB[data.Length-2];

        for (int i = 1; i < data.Length-1; i++)
        {
            string[] row = data[i].Split(new char[] { ';' });
            quotedb[i-1] = new QuoteDB(row[0], row[1], row[2], row[3], row[4]);
        }

        Debug.Log("Preprocess sorun çözüldü");
        Categorize();
    }

    public void Categorize()
    {

        loveDb = (from item in quotedb
                  where item.category.ToString() == quotedb[0].category
                  select item).ToList();

        lifeDb = (from item in quotedb
                  where item.category.ToString() == quotedb[1].category
                  select item).ToList();

        philosophyDb = (from item in quotedb
                        where item.category.ToString() == quotedb[2].category
                        select item).ToList();

        educationDb = (from item in quotedb
                       where item.category.ToString() == quotedb[3].category
                       select item).ToList();

        inspirationalDb = (from item in quotedb
                           where item.category.ToString() == quotedb[4].category
                           select item).ToList();

        artDb = (from item in quotedb
                  where item.category.ToString() == quotedb[5].category
                  select item).ToList();

    }
}
