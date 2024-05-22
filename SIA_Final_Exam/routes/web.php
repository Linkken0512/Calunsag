<?php

use Illuminate\Support\Facades\Route;
use App\Livewire\Student;
use App\Livewire\Dashboard;

Route::get('/', function () {
    return view('welcome');
});

Route::middleware([
    'auth:sanctum',
    config('jetstream.auth_session'),
    'verified',
])->group(function () {
    Route::get('/dashboard', Dashboard::class)->middleware('auth');
});

Route::get('/student', Student::class)->middleware('auth');



