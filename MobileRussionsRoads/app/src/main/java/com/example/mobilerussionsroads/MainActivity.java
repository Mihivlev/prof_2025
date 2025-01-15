package com.example.mobilerussionsroads;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.example.mobilerussionsroads.classes.API;
import com.example.mobilerussionsroads.classes.EventAdapter;
import com.example.mobilerussionsroads.classes.Events;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        Context context = this;
        API.LoadEvents(context);

        RecyclerView v = findViewById(R.id.RVForEvents);
        EventAdapter adapter = new EventAdapter(context, API.AllEvents);
        v.setAdapter(adapter);
    }
    public void ToNews(View view){
        Intent intent = new Intent(this, SecondActivity.class);
        startActivity(intent);
    }
    public void UpdateNews(View view){
        Context context = this;
        API.LoadEvents(context);

        RecyclerView v = findViewById(R.id.RVForEvents);
        EventAdapter adapter = new EventAdapter(context, API.AllEvents);
        v.setAdapter(adapter);
    }
}