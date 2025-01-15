package com.example.mobilerussionsroads.classes;

import static java.time.temporal.TemporalAdjusters.next;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.mobilerussionsroads.R;

import java.util.List;
import java.util.Scanner;

public class EventAdapter extends RecyclerView.Adapter<EventAdapter.EventVH> {
    Context context;
    List<Events> EventsList;

    public EventAdapter(Context context, List<Events> EventsList){
        this.context = context;
        this.EventsList = EventsList;
    }

    @NonNull
    @Override
    public EventVH onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View v = LayoutInflater.from(context).inflate(R.layout.item, parent, false);
        return new EventVH(v);
    }

    @Override
    public int getItemCount() {
        return EventsList.size();
    }

    @Override
    public void onBindViewHolder(@NonNull EventVH holder, int position) {
        holder.Name.setText(EventsList.get(position).getName());
        holder.Text.setText(EventsList.get(position).getDescription());
        holder.Start.setText(EventsList.get(position).getStart().substring(0,10));
        holder.Maker.setText(FindEmployee(EventsList.get(position).getMakerID()));
    }

    private String FindEmployee(int ID){
        for (int i = 0; i<API.AllEmployees.size();i++){
            Employees employee = API.AllEmployees.get(i);
            if (employee.ID == ID) API.EmployeeFIO=employee.FIO;
        }
        return API.EmployeeFIO;
    }
    public class EventVH extends RecyclerView.ViewHolder{
        TextView Name;
        TextView Maker;
        TextView Text;
        TextView Start;
        public EventVH(@NonNull View view){
            super(view);
            Name = view.findViewById(R.id.NewsName);
            Maker = view.findViewById(R.id.NewsAuthor);
            Text = view.findViewById(R.id.NewsText);
            Start = view.findViewById(R.id.NewsDate);
        }
    }
}
