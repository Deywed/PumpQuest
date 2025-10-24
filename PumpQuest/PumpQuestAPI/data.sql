--
-- PostgreSQL database dump
--

-- Dumped from database version 14.13 (Homebrew)
-- Dumped by pg_dump version 14.13 (Homebrew)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Data for Name: Coaches; Type: TABLE DATA; Schema: public; Owner: newuser
--

COPY public."Coaches" ("Id", "Name", "Bio", "Xp", "ImagePath") FROM stdin;
2	Togi	TOGII	100	/Users/macbook/dev/Projekat/PumpQuest/PumpQuestFront/assets/togi/togi_profile.jpg
1	CBUM	Mr Olimpia	1000	/Users/macbook/dev/Projekat/PumpQuest/PumpQuestFront/assets/cbum/cbum_profile.png
\.


--
-- Data for Name: Exercises; Type: TABLE DATA; Schema: public; Owner: newuser
--

COPY public."Exercises" ("Id", "Name") FROM stdin;
1	Bench press
2	Squat
3	Dead lift
\.


--
-- Data for Name: Workouts; Type: TABLE DATA; Schema: public; Owner: newuser
--

COPY public."Workouts" ("Id", "Name", "CoachId", "Description", "Difficulty", "Xp") FROM stdin;
4	power	1	description	easy	0
\.


--
-- Data for Name: WorkoutExercises; Type: TABLE DATA; Schema: public; Owner: newuser
--

COPY public."WorkoutExercises" ("Id", "WorkoutId", "ExerciseId", "Sets", "Reps") FROM stdin;
1	4	1	1	1
2	4	2	2	2
\.


--
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: newuser
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20250927120847_m1	9.0.9
20250927121640_m2	9.0.9
20250927123919_m11	9.0.9
20250929082354_mm1	9.0.9
20250929094532_ma1	9.0.9
\.


--
-- Name: Coaches_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: newuser
--

SELECT pg_catalog.setval('public."Coaches_Id_seq"', 2, true);


--
-- Name: Exercises_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: newuser
--

SELECT pg_catalog.setval('public."Exercises_Id_seq"', 3, true);


--
-- Name: WorkoutExercises_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: newuser
--

SELECT pg_catalog.setval('public."WorkoutExercises_Id_seq"', 2, true);


--
-- Name: Workouts_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: newuser
--

SELECT pg_catalog.setval('public."Workouts_Id_seq"', 4, true);


--
-- PostgreSQL database dump complete
--

