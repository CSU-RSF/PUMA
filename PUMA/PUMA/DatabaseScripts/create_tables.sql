-- Role: PlantUser

-- DROP ROLE "PlantUser";

CREATE ROLE "PlantUser" LOGIN
  ENCRYPTED PASSWORD 'md58aef147ba7993b6de8ae1db942c407b3'
  NOSUPERUSER INHERIT NOCREATEDB NOCREATEROLE NOREPLICATION;


CREATE ROLE "PlantOwner" LOGIN
  ENCRYPTED PASSWORD 'md5afd087ef71117373c96bc71931aaf215'
  NOSUPERUSER INHERIT CREATEDB NOCREATEROLE REPLICATION;

CREATE DATABASE plant
  WITH OWNER = "PlantOwner"
       ENCODING = 'UTF8'
       TABLESPACE = pg_default
       LC_COLLATE = 'English_United States.1252'
       LC_CTYPE = 'English_United States.1252'
       CONNECTION LIMIT = -1;

/*
 * plants table 
 * This table will contain any plant name details that have a 1:1 mapping to plants
 * Other plant name details that have a 1:* mapping will need their own tables
 */
CREATE TABLE plant.plants(
	plant_id serial NOT NULL,
    plant_imported_id integer NOT NULL,
	common_name text NOT NULL,
	common_family_name text NOT NULL,
	scientific_family_name text NOT NULL,
	family_name_meaning text NOT NULL,
	family_characteristics text,
	classification text NOT NULL,
	sub_class text NOT NULL,
  CONSTRAINT plant_id_pk PRIMARY KEY (plant_id))
  WITH (OIDS=FALSE);

ALTER TABLE plant.plants OWNER TO "PlantOwner";
GRANT SELECT ON plant.plants TO "PlantUser";

/*
 * other_common_names table
 * 1:* connects to plants table
 */
CREATE TABLE plant.other_common_names(
	other_common_name_id serial NOT NULL,
	plant_id integer NOT NULL,
other_common_name text NOT NULL,
  CONSTRAINT other_common_name_id_pk PRIMARY KEY (other_common_name_id),
  CONSTRAINT plant_id_fk FOREIGN KEY (plant_id) REFERENCES plant.plants (plant_id) ON UPDATE CASCADE ON DELETE CASCADE)
  WITH (OIDS=FALSE);
ALTER TABLE plant.other_common_names OWNER TO "PlantOwner";
GRANT SELECT ON plant.other_common_names TO "PlantUser";

/*
 * scientific_name table
 * 1:* connects to plants table
 */
CREATE TABLE plant.scientific_name(
	scientific_name_id serial NOT NULL,
	plant_id integer NOT NULL,
subspecies text,
variety text,
authors text,
scientific_name_meaning text,
  CONSTRAINT scientific_name_id_pk PRIMARY KEY (scientific_name_id),
  CONSTRAINT plant_id_fk FOREIGN KEY (plant_id) REFERENCES plant.plants (plant_id) ON UPDATE CASCADE ON DELETE CASCADE)
  WITH (OIDS=FALSE);
ALTER TABLE plant.scientific_name OWNER TO "PlantOwner";
GRANT SELECT ON plant.scientific_name TO "PlantUser";

/*
 * synonyms table
 * 1:* connects to plants table
 */
CREATE TABLE plant.synonyms(
	synonym_id serial NOT NULL,
	plant_id integer NOT NULL,
synonym text NOT NULL,
  CONSTRAINT synonym_id_pk PRIMARY KEY (synonym_id),
  CONSTRAINT plant_id_fk FOREIGN KEY (plant_id) REFERENCES plant.plants (plant_id) ON UPDATE CASCADE ON DELETE CASCADE)
  WITH (OIDS=FALSE);
ALTER TABLE plant.synonyms OWNER TO "PlantOwner";
GRANT SELECT ON plant.synonyms TO "PlantUser";
