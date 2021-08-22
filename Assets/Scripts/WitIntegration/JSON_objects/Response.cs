using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Response {
    public Intent[] intents;
    public string entities;
    public string text;
    public string traits;

}