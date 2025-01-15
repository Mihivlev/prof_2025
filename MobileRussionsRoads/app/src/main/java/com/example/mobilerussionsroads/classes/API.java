package com.example.mobilerussionsroads.classes;

import android.content.Context;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;
import retrofit2.http.GET;

public class API {
    public static List<Employees> AllEmployees = new ArrayList<>();
    public static List<Events> AllEvents = new ArrayList<>();
    public static final String BaseUrl = "http://10.0.2.2:55000/api/";
    public static String EmployeeFIO = "Не найдено";

    public static interface ApiFun{
        @GET("Events")
        Call<List<Events>> GetAllEvents();
        @GET("Employees")
        Call<List<Employees>> GetAllEmployees();
    }
    public static void LoadEvents(Context context){
        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(BaseUrl)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        ApiFun fun = retrofit.create(ApiFun.class);

        fun.GetAllEvents().enqueue(new Callback<List<Events>>() {
            @Override
            public void onResponse(Call<List<Events>> call, Response<List<Events>> response) {
                AllEvents = response.body();
            }

            @Override
            public void onFailure(Call<List<Events>> call, Throwable throwable) {
                Toast.makeText(context, throwable.toString(), Toast.LENGTH_LONG).show();
            }
        });

        fun.GetAllEmployees().enqueue(new Callback<List<Employees>>() {
            @Override
            public void onResponse(Call<List<Employees>> call, Response<List<Employees>> response) {
                AllEmployees = response.body();
            }

            @Override
            public void onFailure(Call<List<Employees>> call, Throwable throwable) {
                Toast.makeText(context, throwable.toString(), Toast.LENGTH_LONG).show();
            }
        });

    }
}
