Stone Assemblies MassAuth Benckmarks
====================================

This repo includes some benchmarks of *[Stone Assemblies MassAuth](https://github.com/stoneassemblies/StoneAssemblies.MassAuth)*.

# Design

For these benchmarks we generated a lot messages and rules types with very simple implementations. The rules and messages are available in StoneAssemblies.MassAuth.Benchmarks. Rules and StoneAssemblies.MassAuth.Benchmarks.Messages NuGet packages.

The goal of theses benchmarks is test the evaluation speed, scalabilty and stability of the solution.

The following diagram shows the components and their interactions.

![Benchmarks Components & & Interactions](images/diagram.png "Benchmarks Components & Interactions")

# Hosting 

The components used in this are the official docker images of Stone Assemblies MassAuth and rules are downloaded directly from the NuGet gallery.   

The software prerequisites to execute these benchmarks.

1) Docker
2) Tye

These benchmarks were written using [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)

# Benchmarks

All benchmarks results were obtained on the following hardware.   

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.201
  [Host]     : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT
  DefaultJob : .NET Core 5.0.4 (CoreCLR 5.0.421.11614, CoreFX 5.0.421.11614), X64 RyuJIT


```

## Single Message

For this benckmark we run 3 instances of the authorization engine with some rules per message type. A single one message is sent and all rules are evaluate. 

|         Rules Count |     Mean |    Error |   StdDev |   Median |
|-------------------- |---------:|---------:|---------:|---------:|
| **1**   | **297.9 ms** | **28.85 ms** | **84.14 ms** | **300.6 ms** |
| **5**   | **241.9 ms** | **22.53 ms** | **65.36 ms** | **223.0 ms** |
| **10**  | **289.5 ms** | **21.75 ms** | **62.42 ms** | **298.1 ms** |
| **20**  | **297.2 ms** | **29.08 ms** | **84.37 ms** | **297.0 ms** |
| **50**  | **247.7 ms** | **30.87 ms** | **87.07 ms** | **235.1 ms** |
| **100** | **154.9 ms** | **18.87 ms** | **51.98 ms** | **136.9 ms** |


## Multiple Messages

For this benckmark we run 3 instances of the authorization engine with some rules per message type. Some messages are sent at the same time (max 5) and all rules are evaluate. 

|         Rules Count | Parallel Requests |     Mean |    Error |    StdDev |    Median |
|-------------------- |------------ |---------:|---------:|----------:|----------:|
| **1**   | **1** | **199.6 ms** |  **6.14 ms** |  **18.10 ms** | **196.96 ms** |
| **1**   | **3** | **193.6 ms** | **11.64 ms** |  **32.82 ms** | **197.79 ms** |
| **1**   | **5** | **217.4 ms** | **24.23 ms** |  **69.52 ms** | **214.62 ms** |
| **5**   | **1** | **196.5 ms** | **16.35 ms** |  **47.44 ms** | **203.48 ms** |
| **5**   | **3** | **200.8 ms** |  **7.86 ms** |  **22.42 ms** | **197.97 ms** |
| **5**   | **5** | **242.7 ms** | **17.61 ms** |  **48.79 ms** | **236.01 ms** |
| **10**  | **1** | **166.9 ms** | **14.24 ms** |  **39.00 ms** | **170.72 ms** |
| **10**  | **3** | **186.0 ms** |  **7.31 ms** |  **20.99 ms** | **176.48 ms** |
| **10**  | **5** | **190.7 ms** | **22.97 ms** |  **67.72 ms** | **184.40 ms** |
| **20**  | **1** | **156.6 ms** |  **6.42 ms** |  **18.82 ms** | **153.25 ms** |
| **20**  | **3** | **209.7 ms** | **21.83 ms** |  **63.32 ms** | **226.42 ms** |
| **20**  | **5** | **107.8 ms** | **13.07 ms** |  **35.34 ms** |  **91.41 ms** |
| **50**  | **1** | **185.6 ms** |  **7.89 ms** |  **22.39 ms** | **189.50 ms** |
| **50**  | **3** | **211.9 ms** | **14.03 ms** |  **37.68 ms** | **203.05 ms** |
| **50**  | **5** | **263.9 ms** | **33.81 ms** |  **98.09 ms** | **212.48 ms** |
| **100** | **1** | **173.6 ms** |  **6.59 ms** |  **19.02 ms** | **171.15 ms** |
| **100** | **3** | **202.4 ms** |  **8.64 ms** |  **23.20 ms** | **202.19 ms** |
| **100** | **5** | **290.2 ms** | **38.43 ms** | **111.48 ms** | **230.96 ms** |


## Scalability and stability

For this benckmark we run 5 instances of the authorization engine with some rules per message type. Some messages are sent at the same time (max 10) and all rules are evaluate. 

|      Rules Count | Parallel Requests |     Mean |    Error |    StdDev |   Median |
|----------------- |------------ |---------:|---------:|----------:|---------:|
| **1**   |  **1** | **242.5 ms** | **18.12 ms** |  **52.28 ms** | **228.2 ms** |
| **1**   |  **3** | **289.8 ms** | **23.20 ms** |  **67.67 ms** | **284.5 ms** |
| **1**   |  **5** | **295.7 ms** | **51.92 ms** | **147.28 ms** | **257.9 ms** |
| **1**   | **10** | **523.9 ms** | **38.66 ms** | **109.05 ms** | **530.5 ms** |
| **5**   |  **1** | **293.9 ms** | **21.85 ms** |  **63.03 ms** | **274.1 ms** |
| **5**   |  **3** | **340.5 ms** | **33.84 ms** |  **96.55 ms** | **299.1 ms** |
| **5**   |  **5** | **291.7 ms** | **41.42 ms** | **114.78 ms** | **294.6 ms** |
| **5**   | **10** | **543.0 ms** | **49.56 ms** | **142.18 ms** | **548.4 ms** |
| **10**  |  **1** | **277.2 ms** | **18.75 ms** |  **53.20 ms** | **262.6 ms** |
| **10**  |  **3** | **299.4 ms** | **29.84 ms** |  **85.13 ms** | **263.0 ms** |
| **10**  |  **5** | **325.6 ms** | **52.91 ms** | **150.96 ms** | **314.6 ms** |
| **10**  | **10** | **598.6 ms** | **53.63 ms** | **154.72 ms** | **577.6 ms** |
| **20**  |  **1** | **203.0 ms** | **16.90 ms** |  **48.22 ms** | **196.2 ms** |
| **20**  |  **3** | **293.9 ms** | **29.20 ms** |  **85.18 ms** | **277.0 ms** |
| **20**  |  **5** | **337.1 ms** | **45.64 ms** | **132.41 ms** | **302.6 ms** |
| **20**  | **10** | **351.5 ms** | **24.64 ms** |  **70.30 ms** | **335.7 ms** |
| **50**  |  **1** | **311.3 ms** | **27.17 ms** |  **78.38 ms** | **296.5 ms** |
| **50**  |  **3** | **327.5 ms** | **37.54 ms** | **107.72 ms** | **294.1 ms** |
| **50**  |  **5** | **569.5 ms** | **77.58 ms** | **226.31 ms** | **553.8 ms** |
| **50**  | **10** | **671.8 ms** | **80.30 ms** | **235.49 ms** | **607.7 ms** |
| **100** |  **1** | **486.4 ms** | **42.53 ms** | **124.74 ms** | **462.6 ms** |
| **100** |  **3** | **533.2 ms** | **62.78 ms** | **178.08 ms** | **492.2 ms** |
| **100** |  **5** | **426.8 ms** | **56.73 ms** | **165.48 ms** | **417.7 ms** |
| **100** | **10** | **354.6 ms** | **24.68 ms** |  **70.82 ms** | **337.0 ms** |


## Alright let's do this one last time

For this benckmark we run 5 instances of the authorization engine with some rules per message type. Some messages are sent at the same time (max 200) and all rules are evaluate. 

| Rules Count | Parallel Requests |       Mean |     Error |   StdDev |
|----------- |----------------- |-----------:|----------:|---------:|
| **100** | **100** |   **805.0 ms** |  **70.14 ms** | **192.0 ms** |


```
Mean = 805.041 ms, StdErr = 20.584 ms (2.56%), N = 87, StdDev = 191.994 ms                                            
Min = 517.638 ms, Q1 = 657.391 ms, Median = 765.463 ms, Q3 = 933.272 ms, Max = 1,291.131 ms                           
IQR = 275.881 ms, LowerFence = 243.570 ms, UpperFence = 1,347.093 ms                                                  
ConfidenceInterval = [734.906 ms; 875.177 ms] (CI 99.9%), Margin = 70.135 ms (8.71% of Mean)                          
Skewness = 0.56, Kurtosis = 2.48, MValue = 3.25                                                                       
-------------------- Histogram --------------------                                                                   
[  512.651 ms ;   626.390 ms) | @@@@@@@@@@@@@@@@@@@@                                                                  
[  626.390 ms ;   681.983 ms) | @@@@@                                                                                 
[  681.983 ms ;   795.723 ms) | @@@@@@@@@@@@@@@@@@@@@@@@                                                              
[  795.723 ms ;   939.638 ms) | @@@@@@@@@@@@@@@@@                                                                     
[  939.638 ms ; 1,091.099 ms) | @@@@@@@@@@@@@                                                                         
[1,091.099 ms ; 1,212.496 ms) | @@@@@@                                                                                
[1,212.496 ms ; 1,348.000 ms) | @@                                                                                    
---------------------------------------------------                                                                   
```   

| Rules Count | Parallel Requests |       Mean |     Error |   StdDev |
|----------- |----------------- |-----------:|----------:|---------:|
| **100** | **200** | **1,585.9 ms** | **199.28 ms** | **562.1 ms** |

```
Mean = 1.586 s, StdErr = 0.059 s (3.69%), N = 92, StdDev = 0.562 s                                                    
Min = 0.734 s, Q1 = 1.123 s, Median = 1.548 s, Q3 = 1.778 s, Max = 3.127 s                                            
IQR = 0.656 s, LowerFence = 0.139 s, UpperFence = 2.762 s                                                             
ConfidenceInterval = [1.387 s; 1.785 s] (CI 99.9%), Margin = 0.199 s (12.57% of Mean)                                 
Skewness = 0.84, Kurtosis = 2.92, MValue = 3.86                                                                       
-------------------- Histogram --------------------                                                                   
[0.570 s ; 0.956 s) | @@@@@                                                                                           
[0.956 s ; 1.283 s) | @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                                                                  
[1.283 s ; 1.454 s) | @@@@@@                                                                                          
[1.454 s ; 1.780 s) | @@@@@@@@@@@@@@@@@@@@@@@@@@@@                                                                    
[1.780 s ; 2.157 s) | @@@@@@@                                                                                         
[2.157 s ; 2.484 s) | @@@@@@                                                                                          
[2.484 s ; 2.878 s) | @@@@@@@@@                                                                                       
[2.878 s ; 3.290 s) | @                                                                                               
---------------------------------------------------         
```                                                          
