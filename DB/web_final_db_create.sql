BEGIN
  EXECUTE IMMEDIATE 'DROP TABLE lee_gifts';
  EXECUTE IMMEDIATE 'DROP TABLE lee_msgs';
  EXECUTE IMMEDIATE 'DROP TABLE lee_persons';
  EXECUTE IMMEDIATE 'DROP TABLE lee_jobs';

EXCEPTION
  WHEN OTHERS THEN DBMS_OUTPUT.PUT_LINE('');
END;
/
show errors

CREATE TABLE lee_jobs
(
  job_id NUMBER CONSTRAINT lee_jobs_job_id_pk PRIMARY KEY,
  job_type VARCHAR2(15) NOT NULL,
  job_title VARCHAR2(30) NOT NULL,
  job_info VARCHAR2(2000) NOT NULL,
  job_start_date DATE NOT NULL,
  job_end_date DATE DEFAULT null,
  job_location VARCHAR2(20) NOT NULL,
  job_salary NUMBER(9,2) DEFAULT 0.00,
  job_contacts_id NUMBER NOT NULL,
  CONSTRAINT lee_jobs_job_type_ck CHECK (job_type = 'VOLUNTEER' OR job_type = 'EMPLOYEE')
);

CREATE TABLE lee_persons
(
  person_id NUMBER CONSTRAINT lee_persons_person_id_pk PRIMARY KEY,
  person_last_name VARCHAR2(50) NOT NULL,
  person_first_name VARCHAR2(50) NOT NULL,
  person_status VARCHAR2(15) NOT NULL,
  person_phone VARCHAR2(20) UNIQUE,
  person_address VARCHAR2(50) DEFAULT null,
  person_city VARCHAR2(50) DEFAULT null,
  person_state CHAR(2) DEFAULT null,
  person_zip_code VARCHAR2(20) DEFAULT null,
  person_email VARCHAR2(50) UNIQUE,
  person_balance NUMBER(9,2) DEFAULT 0.00,
  person_applied_job_id NUMBER DEFAULT null,
  CONSTRAINT lee_persons_person_applied_job_id_fk FOREIGN KEY (person_applied_job_id) REFERENCES lee_jobs(job_id),
  CONSTRAINT lee_persons_person_status_ck CHECK (person_status = 'DOCTOR' OR person_status = 'NURSE' OR person_status = 'VOLUNTEER' OR person_status = 'CANDIDATE' OR person_status = 'SHOPOWNER' OR person_status = 'HR' OR person_status = 'OTHER')
);

CREATE TABLE lee_msgs
(
  msg_id NUMBER CONSTRAINT lee_msgs_msg_id PRIMARY KEY,
  msg_info VARCHAR2(500) NOT NULL,
  msg_previous_owner_id NUMBER NOT NULL,
  msg_owner_id NUMBER NOT NULL,
  CONSTRAINT lee_msgs_previous_owner_id_fk FOREIGN KEY (msg_previous_owner_id) REFERENCES lee_persons(person_id),
  CONSTRAINT lee_msgs_owner_id_fk FOREIGN KEY (msg_owner_id) REFERENCES lee_persons(person_id)
);

-- gift_previous_owner_id is used for checking gift giver
CREATE TABLE lee_gifts
(
  gift_id NUMBER CONSTRAINT lee_gifts_gift_id_pk PRIMARY KEY,
  gift_type VARCHAR2(15) NOT NULL,
  gift_info VARCHAR2(200) NOT NULL UNIQUE,
  gift_price NUMBER(9,2) DEFAULT 0.00,
  gift_previous_owner_id NUMBER NOT NULL,
  gift_owner_id NUMBER NOT NULL,
  CONSTRAINT lee_gifts_gift_previous_owner_id_fk FOREIGN KEY (gift_previous_owner_id) REFERENCES lee_persons(person_id),
  CONSTRAINT lee_gifts_gift_owner_id_fk FOREIGN KEY (gift_owner_id) REFERENCES lee_persons(person_id),
  CONSTRAINT lee_gifts_gift_type_ck CHECK (gift_type = 'E-CARD' OR gift_type = 'FLOWER' OR gift_type = 'FOOD' OR gift_type = 'DRINK')
  );

-- INSERT jobs' info
INSERT INTO lee_jobs VALUES (30, 'VOLUNTEER', 'volunteer - cleaning', 'clean some places', '12-JAN-18', '12-FEB-18', 'Toronto', default, 9);
INSERT INTO lee_jobs VALUES (31, 'VOLUNTEER', 'volunteer - senior care', 'care senior people', '1-FEB-18', '1-JUN-18', 'North York', default, 9);
INSERT INTO lee_jobs VALUES (32, 'EMPLOYEE', 'employee - doctor', 'family doctor', '1-JAN-18', default, 'Toronto', 3000, 9);
INSERT INTO lee_jobs VALUES (33, 'EMPLOYEE', 'employee - doctor', 'operation dortor', '1-JAN-18', default, 'North York', 6000, 9);
INSERT INTO lee_jobs VALUES (34, 'EMPLOYEE', 'employee - nurse', 'common nurse', '1-JAN-18', default, 'Toronto', 2000, 9);
INSERT INTO lee_jobs VALUES (35, 'EMPLOYEE', 'employee - nurse', 'operation nurse', '1-JAN-18', default, 'North York', 4000, 9);

--insert persons' info
INSERT INTO lee_persons VALUES (-1, 'Place', 'Holder', 'OTHER', '000-000-0000', 'placeholder st', 'Placeholder', 'PO', '00000', 'placeholder@gmail.com', '0.00', default);
INSERT INTO lee_persons VALUES (0, 'Arodondo', 'Cesar', 'DOCTOR', '810-555-3700', '4545 Glenmeade Lane', 'Auburn Hills', 'MI', '48326', 'carodondo@gmail.com', '19.99', default);
INSERT INTO lee_persons VALUES (1, 'Danielson', 'Rachael', 'DOCTOR', '559-555-1704', '353 E shaw Ave', 'Fresno', 'CA', '93710', 'rdanielson@gmail.com', '29.99', default);
INSERT INTO lee_persons VALUES (2, 'Alondra', 'Zev', 'NURSE', '800-255-6210', 'PO Box 610', 'Olathe', 'KS', '66061', 'zalondra@gmail.com', '39.99', default);
INSERT INTO lee_persons VALUES (3, 'Edgardo', 'Salina', 'NURSE', '559-555-7070', '6435 North Palm Ave, ste 101', 'Fresno', 'CA', '93704', 'sedgardo@gmail.com', '9.99', default);
INSERT INTO lee_persons VALUES (4, 'Bradlee', 'Daniel', 'VOLUNTEER', '908-555-7222', '4 Cornwall Dr ste 102', 'East Brunswick', 'NJ', '08816', 'dbradlee@gmail.com', '19.99', default);
INSERT INTO lee_persons VALUES (5, 'Dean', 'Julissa', 'VOLUNTEER', '961-555-4911', 'PO Box 942808', 'Sacramento', 'CA', '94208', 'jdeam@gmail.com', '29.99', default);
INSERT INTO lee_persons VALUES (6, 'Marissa', 'Kyle', 'CANDIDATE', '559-555-6151', '1627 E street', 'Fresno', 'CA', '93706', 'kmarissa@gmail.com', '0.00', 30);
INSERT INTO lee_persons VALUES (7, 'Warren', 'Quentin', 'CANDIDATE', '559-555-3113', 'PO Box 12332', 'Fresno', 'CA', '93777', 'qwarren@gmail.comm', '0.00', 31);
INSERT INTO lee_persons VALUES (8, 'Eulalia', 'Kelsey', 'SHOPOWNER', '215-555-1500', 'P O Box 7247-7844', 'Philadelphia', 'PA', '19170', 'keulalia@gmail.com', '199.99', default);
INSERT INTO lee_persons VALUES (9, 'Kapil', 'Robert', 'HR', '800-555-0344', 'P.O. Box 21209', 'Pasadena', 'CA', '91185', 'rkapil@gmail.com', '99.99', default);

-- INSERT msgs' info
INSERT INTO lee_msgs VALUES (10, 'hi, could you help to do something?', -1, 6);
INSERT INTO lee_msgs VALUES (11, 'I need help', -1, 3);

-- INSERT gifts' info
INSERT INTO lee_gifts VALUES (20, 'E-CARD', 'happy new year', 1.99, -1, 8);
INSERT INTO lee_gifts VALUES (21, 'E-CARD', 'happy birthday', 1.99, -1, 8);
INSERT INTO lee_gifts VALUES (22, 'FLOWER', '12 roses', 9.99, -1, 8 );
INSERT INTO lee_gifts VALUES (23, 'FLOWER', '12 lilies', 9.99, -1, 8 );
INSERT INTO lee_gifts VALUES (24, 'FOOD', 'fries and chicken', 6.99, -1, 8 );
INSERT INTO lee_gifts VALUES (25, 'FOOD', 'pizza', 1.99, -1, 8 );
INSERT INTO lee_gifts VALUES (26, 'DRINK', 'coke', 0.99, -1, 8 );
INSERT INTO lee_gifts VALUES (27, 'DRINK', 'beer', 1.99, -1, 8 );
